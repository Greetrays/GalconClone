using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class Player : MonoBehaviour
{
    [SerializeField] private int _startShipCount;
    [SerializeField] private Ship _shipTemplate;

    protected PlanetShip SelectPlanet;
    protected PlanetShip TargetPlanet;
    protected List<PlanetShip> OccupiedPlanets = new List<PlanetShip>();
    protected List<PlanetShip> FreePlanets = new List<PlanetShip>();

    public Color Color { get; protected set; }

    public void AddOccupiedPlanet(PlanetShip planet)
    {
        OccupiedPlanets.Add(planet);
        FreePlanets.Remove(planet);
    }

    public void RemoveOccupiedPlanet(PlanetShip planet)
    {
        OccupiedPlanets.Remove(planet);
        FreePlanets.Add(planet);
    }

    public void RestartData(PlanetContainer planetContainer)
    {
        OccupiedPlanets.Clear();
        FreePlanets.Clear();
        FillFreePlanets(planetContainer);
        SetStartPlanet();
    }

    protected bool TrySelectPlanet(List<PlanetShip> planets, ref PlanetShip planetShip)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector3.forward);

            if (hit.collider == null)
                return false;

            if (hit.collider.TryGetComponent(out PlanetShip planet))
            {
                foreach (var planetItem in planets)
                {
                    if (planetItem.gameObject == planet.gameObject)
                    {
                        planetShip = planet;
                        return true;
                    }
                }
            }
        }

        return false;
    }

    protected void SpawnShips(ShipContainer shipContainer)
    {
        int countShips = SelectPlanet.GiveHalfShips();

        for (int i = 0; i < countShips; i++)
        {
            Ship newShip = Instantiate(_shipTemplate, SelectPlanet.transform.position, Quaternion.identity, shipContainer.transform);
            newShip.Init(TargetPlanet, this);
        }
    }

    private void SetStartPlanet()
    {
        PlanetShip startPlanet = FreePlanets.FirstOrDefault(planet => planet.HasOvner == false);
        AddOccupiedPlanet(startPlanet);
        startPlanet.Init(_startShipCount, Color, this);
    }

    private void FillFreePlanets(PlanetContainer shipContainer)
    {
        for (int i = 0; i < shipContainer.transform.childCount; i++)
        {
            PlanetShip newPlanet = shipContainer.transform.GetChild(i).GetComponent<PlanetShip>();
            FreePlanets.Add(newPlanet);
        }
    }
}
