using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]

public class Planet : MonoBehaviour
{
    [SerializeField] private float _minScale;
    [SerializeField] private float _maxScale;
  //  [SerializeField] private int _minStartShips;
   // [SerializeField] private int _maxStartShips;
   // [SerializeField] private float _delayReplenishment;
    [SerializeField] private Sprite _defaultSprite;
    [SerializeField] private Sprite _selectSprite;

   // private Player _ovner;
    //private float _elepsedTime;
    private SpriteRenderer _spriteRenderer;

   // public event UnityAction<int> Filling;
    //public event UnityAction<Planet, Player> Captured;

    public Color CurrentColor { get; private set; }
   // public int CountShips { get; private set; }
   // public bool HasOvner => _ovner != null;

    private void Awake()
    {      
        _spriteRenderer = GetComponent<SpriteRenderer>();
        //SetShipCount(Random.Range(_minStartShips, _maxStartShips));
    }

    private void Start()
    {
        //Filling?.Invoke(CountShips);
        CurrentColor = _spriteRenderer.color;
        float randomScale = Random.Range(_minScale, _maxScale);
        transform.localScale = new Vector3(randomScale, randomScale);
    }

  /*  private void Update()
    {
        ReplenishmentShips();
    }
  */
  /*  private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Ship ship))
        {
            if (ship.TargetPlanet == this)
            {
                if (CurrentColor == ship.Ovner.Color)
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
                        SetColor(ship.Ovner.Color);
                    }
                }
            }
        }
    }*/

    public void SwitchSpritePlanet(bool isSelect)
    {
        if (isSelect == true)
        {
            _spriteRenderer.sprite = _selectSprite;
        }
        else
        {
            _spriteRenderer.sprite = _defaultSprite;
        }
    }

    /*public void ReplenishmentShips()
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
    }*/

  /*  public int GiveHalfShips()
    {
        int halfShipsCount = CountShips / 2;
        CountShips = halfShipsCount;
        SetShipCount(halfShipsCount);
        return CountShips;
    }*/

   /* public void Init(int countShip, Color color, Player ovner)
    {
        _ovner = ovner;
        SetShipCount(countShip);
        SetColor(color);
    }*/

   /* private void SetShipCount(int countShip)
    {
        CountShips = countShip;
        Filling?.Invoke(CountShips);
    }*/

    public void SetColor(Color color)
    {
        _spriteRenderer.color = color;
        CurrentColor = color;
    }
}
