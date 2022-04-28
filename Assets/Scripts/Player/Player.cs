using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class Player : MonoBehaviour
{
    [SerializeField] private Color _color;
    [SerializeField] private Transform _planetContainer;
    [SerializeField] private Transform _shipContainer;
    [SerializeField] private int _startShipCount;
    [SerializeField] private Ship _shipTemplate;

    protected PlanetShip SelectPlanet;
    protected PlanetShip TargetPlanet;
    protected List<PlanetShip> OccupiedPlanets = new List<PlanetShip>();
    protected List<PlanetShip> FreePlanets = new List<PlanetShip>();

    public Color Color => _color;

    private void Start()
    {
        FillFreePlanets();
        SetStartPlanet();
    }

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

    protected void SpawnShips()
    {
        int countShips = SelectPlanet.GiveHalfShips();

        for (int i = 0; i < countShips; i++)
        {
            Ship newShip = Instantiate(_shipTemplate, SelectPlanet.transform.position, Quaternion.identity, _shipContainer);
            newShip.Init(TargetPlanet, this);
        }
    }

    private void SetStartPlanet()
    {
        PlanetShip startPlanet = FreePlanets.FirstOrDefault(planet => planet.HasOvner == false);
        AddOccupiedPlanet(startPlanet);
        startPlanet.Init(_startShipCount, _color, this);
    }

    private void FillFreePlanets()
    {
        for (int i = 0; i < _planetContainer.childCount; i++)
        {
            PlanetShip newPlanet = _planetContainer.GetChild(i).GetComponent<PlanetShip>();
            FreePlanets.Add(newPlanet);
        }
    }
}
