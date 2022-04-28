using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Planet _planetTemplate;
    [SerializeField] private Transform _container;
    [SerializeField] private int _countPlanet;

    private Vector2 _maxScreenSize;
    private Vector2 _minScreenSize;
    private List<Planet> _planets = new List<Planet>();

    private void Awake()
    {
        _maxScreenSize = Camera.main.ViewportToWorldPoint(new Vector2(0.95f, 0.95f));
        _minScreenSize = Camera.main.ViewportToWorldPoint(new Vector2(0.05f, 0.05f));

        SpawnPlanet(GetRandomPosition());

        for (int i = 1; i < _countPlanet; i++)
        {
            SpawnPlanet(GetFreePosition());
        }
    }

    private void SpawnPlanet(Vector2 newPosition)
    {
        Planet newPlanet = Instantiate(_planetTemplate, newPosition, Quaternion.identity, _container);
        _planets.Add(newPlanet);
    }

    private Vector2 GetFreePosition()
    {
        bool isSearch = false;
        Vector2 newPosition = Vector2.zero;

        while (isSearch == false)
        {
            newPosition = GetRandomPosition();
            isSearch = CheckDistance(newPosition);
        }
        
        return newPosition;
    }

    private bool CheckDistance(in Vector2 newPosition)
    {     
        for (int i = 0; i < _planets.Count; i++)
        {
            if (Vector2.Distance(newPosition, _planets[i].transform.position) < _planets[i].GetComponent<Renderer>().bounds.size.x)
                return false;
        }

        return true;
    }

    private Vector2 GetRandomPosition()
    {
        float _randomX = Random.Range(_minScreenSize.x, _maxScreenSize.x);
        float _randomY = Random.Range(_minScreenSize.y, _maxScreenSize.y);
        Vector2 newPosition = new Vector2(_randomX, _randomY);
        return newPosition;
    }
}
