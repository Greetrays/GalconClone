using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class CountShipView : MonoBehaviour
{
    [SerializeField] private PlanetShip _planetShip;

    private Text _countShipText;

    private void OnEnable()
    {
        _countShipText = GetComponent<Text>();
        _planetShip.Filling += OnFilling;
    }

    private void OnDisable()
    {
        _planetShip.Filling -= OnFilling;
    }

    private void OnFilling(int countShip)
    {
        _countShipText.text = countShip.ToString();
    }
}
