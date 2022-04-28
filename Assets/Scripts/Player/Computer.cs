using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : Player
{
    [SerializeField] private float _delayBetweemSelect;

    private float _elepsedTime;

    private void Update()
    {
        Select();
    }

    private void Select()
    {
        if (FreePlanets.Count > 0 && OccupiedPlanets.Count > 0)
        {
            _elepsedTime += Time.deltaTime;

            if (_elepsedTime >= _delayBetweemSelect)
            {
                SelectPlanet = OccupiedPlanets[Random.Range(0, OccupiedPlanets.Count)];
                TargetPlanet = FreePlanets[Random.Range(0, FreePlanets.Count)];
                SpawnShips();
                _elepsedTime = 0;
            }
        }
    }
}
