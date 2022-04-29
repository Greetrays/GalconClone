using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPlayerSpawner : MonoBehaviour
{
    [SerializeField] private Computer _computerTemplate;
    [SerializeField] private PlanetContainer _planetContainer;
    [SerializeField] private ShipContainer _shipContainer;
    [SerializeField] private PlayerContainer _playersContainer;

    private List<Computer> _computers = new List<Computer>();

    public void Restart(int numberComputers, float minDelayBetweemReleaseShip, float maxDelayBetweemReleaseShip)
    {
        _computers.Clear();
        SpawmComputers(numberComputers, minDelayBetweemReleaseShip, maxDelayBetweemReleaseShip);
    }

    private void SpawmComputers(int numberComputers, float minDelayBetweemReleaseShip, float maxDelayBetweemReleaseShip)
    {
        for (int i = 0; i < numberComputers; i++)
        {
            Computer newComputer = Instantiate(_computerTemplate, _playersContainer.transform);
            _computers.Add(newComputer);
            newComputer.InitComputer(_planetContainer, _shipContainer, minDelayBetweemReleaseShip, maxDelayBetweemReleaseShip);
        }
    }
}
