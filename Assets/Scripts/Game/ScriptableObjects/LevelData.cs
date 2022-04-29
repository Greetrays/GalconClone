using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLevel", menuName = "Level/Create new level", order = 51)]

public class LevelData : ScriptableObject
{
    [SerializeField] private int _planetCount;
    [SerializeField] private float _minDelayBetweemReleaseShip;
    [SerializeField] private float _maxDelayBetweemReleaseShip;
    [SerializeField] private int _numberComputerPlayers;

    public int PlanetCount => _planetCount;
    public float MinDelayBetweemReleaseShip => _minDelayBetweemReleaseShip;
    public float MaxDelayBetweemReleaseShip => _maxDelayBetweemReleaseShip;
    public int NumberComputerPlayers => _numberComputerPlayers;
}
