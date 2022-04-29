using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]

public class Planet : MonoBehaviour
{
    [SerializeField] private float _minScale;
    [SerializeField] private float _maxScale;
    [SerializeField] private Sprite _defaultSprite;
    [SerializeField] private Sprite _selectSprite;

    private SpriteRenderer _spriteRenderer;

    public Color CurrentColor { get; private set; }

    private void Awake()
    {      
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        CurrentColor = _spriteRenderer.color;
        float randomScale = Random.Range(_minScale, _maxScale);
        transform.localScale = new Vector3(randomScale, randomScale);
    }

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

    public void SetColor(Color color)
    {
        _spriteRenderer.color = color;
        CurrentColor = color;
    }
}
