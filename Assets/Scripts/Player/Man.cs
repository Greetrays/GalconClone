using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Man : Player
{
    private PlanetShip _previousSelectPlanet;

    private void Update()
    {
        Select();
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
                SpawnShips();
                SelectPlanet.GetComponent<Planet>().SwitchSpritePlanet(false);
                SelectPlanet = null;
                TargetPlanet = null;
            }
        }
    }
}
