using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Unit : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction)
    {
        _rigidbody.AddForce(direction * _speed, ForceMode.Impulse);
    }
}
