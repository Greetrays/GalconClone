using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Planet))]

public class PlanetShip : MonoBehaviour
{
    [SerializeField] private float _delayReplenishment;
    [SerializeField] private int _minStartShips;
    [SerializeField] private int _maxStartShips;

    private Planet _planet;
    private Player _ovner;
    private float _elepsedTime;

    public event UnityAction<int> Filling;
    public int CountShips { get; private set; }
    public bool HasOvner => _ovner != null;

    private void Awake()
    {
        _planet = GetComponent<Planet>();
        SetShipCount(Random.Range(_minStartShips, _maxStartShips));
    }

    private void Start()
    {
        Filling?.Invoke(CountShips);
    }

    private void Update()
    {
        ReplenishmentShips();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Ship ship))
        {
            if (ship.TargetPlanet == this)
            {
                if (_planet.CurrentColor == ship.Ovner.Color)
                {
                    SetShipCount(CountShips + 1);
                }
                else
                {
                    SetShipCount(CountShips - 1);

                    if (CountShips <= 0)
                    {
                        if (_ovner != null)
                            _ovner.RemoveOccupiedPlanet(this);

                        _ovner = ship.Ovner;
                        _ovner.AddOccupiedPlanet(this);
                        _planet.SetColor(ship.Ovner.Color);
                    }
                }
            }
        }
    }

    public void ReplenishmentShips()
    {
        if (HasOvner)
        {
            _elepsedTime += Time.deltaTime;

            if (_elepsedTime >= _delayReplenishment)
            {
                SetShipCount(++CountShips);
                _elepsedTime = 0;
            }
        }
    }

    public int GiveHalfShips()
    {
        int halfShipsCount = CountShips / 2;
        CountShips = halfShipsCount;
        SetShipCount(halfShipsCount);
        return CountShips;
    }

    public void Init(int countShip, Color color, Player ovner)
    {
        _ovner = ovner;
        SetShipCount(countShip);
        _planet.SetColor(color);
    }


    private void SetShipCount(int countShip)
    {
        CountShips = countShip;
        Filling?.Invoke(CountShips);
    }
}
