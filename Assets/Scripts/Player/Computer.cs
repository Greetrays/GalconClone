using UnityEngine;

public class Computer : Player
{
    [SerializeField] private float _minDelayBetweemSelect;
    [SerializeField] private float _maxDelayBetweemSelect;

    private Color _color;
    private float _elepsedTime;
    private float _delayBetweemSelect;
    private ShipContainer _shipContainer;

    private void Start()
    {
        _delayBetweemSelect = Random.Range(_minDelayBetweemSelect, _maxDelayBetweemSelect);
    }

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
                SpawnShips(_shipContainer);
                _elepsedTime = 0;
            }
        }
    }

    public void InitComputer(PlanetContainer planetContainer, ShipContainer shipContainer)
    {
        _color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
        _shipContainer = shipContainer;
        Color = _color;
        RestartData(planetContainer);
    }
}
