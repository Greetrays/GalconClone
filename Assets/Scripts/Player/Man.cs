using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Man : Player
{
    [SerializeField] private PlanetContainer _planetContainer;
    [SerializeField] private ShipContainer _shipContainer;
    [SerializeField] private Color _color;

    private PlanetShip _previousSelectPlanet;

    private void Awake()
    {
        Color = _color;
    }

    private void Update()
    {
        Select();
    }

    public void Restart()
    {
        RestartData(_planetContainer);
    }

    private void Select()
    {
        if (TrySelectPlanet(OccupiedPlanets, ref SelectPlanet))
        {
            if (_previousSelectPlanet != null)
                _previousSelectPlanet.GetComponent<Planet>().SwitchSpritePlanet(false);

            SelectPlanet.GetComponent<Planet>().SwitchSpritePlanet(true);
            _previousSelectPlanet = SelectPlanet;
        }

        if (SelectPlanet != null)
        {
            if (TrySelectPlanet(FreePlanets, ref TargetPlanet))
            {
                SpawnShips(_shipContainer);
                SelectPlanet.GetComponent<Planet>().SwitchSpritePlanet(false);
                SelectPlanet = null;
                TargetPlanet = null;
            }
        }
    }
}
