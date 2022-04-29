using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLauncher : MonoBehaviour
{
    [SerializeField] private LevelData _levelData;
    [SerializeField] private ComputerPlayerSpawner _computerSpawner;
    [SerializeField] private PlanetSpawner _planetSpawner;
    [SerializeField] private Man _manPlayer;

    private void Start()
    {
        LaunchNextLevel(_levelData);
    }

    private void LaunchNextLevel(LevelData level)
    {
        _planetSpawner.Restart(_levelData.PlanetCount);
        _computerSpawner.Restart(_levelData.NumberComputerPlayers);
        _manPlayer.Restart();
    }
}
