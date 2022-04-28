using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private ParticleSystem _boomParticle;

    private SpriteRenderer _spriteRenderer;
    public PlanetShip TargetPlanet { get; private set; }
    public Player Ovner { get; private set; }

    private void OnEnable()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Planet planet))
        {
            if (planet.gameObject == TargetPlanet.gameObject)
            {
                Instantiate(_boomParticle, gameObject.transform.position, _boomParticle.transform.rotation);
                Destroy(gameObject);
            }
        }
    }

    public void Init(PlanetShip targetPlanet, Player ovner)
    {
        TargetPlanet = targetPlanet;
        Ovner = ovner;
        _spriteRenderer.color = Ovner.Color;
    }
}
