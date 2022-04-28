using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Ship))]

public class ShipMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Ship _ship;

    private void Start()
    {
        _ship = GetComponent<Ship>();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _ship.TargetPlanet.transform.position, _speed * Time.deltaTime);
        Rotate();
    }

    private void Rotate()
    {
        float correctionDegree = 90;
        Vector3 difference = _ship.TargetPlanet.transform.position - transform.position;
        difference.Normalize();
        float zRotation = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, zRotation - correctionDegree);
    }
}
