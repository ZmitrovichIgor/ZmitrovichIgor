using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    private void Awake() // выпоняеися первее старта
    {
        _rigidbody = GetComponent<Rigidbody>(); // компонент физики 
    }

    public void Fly(Vector3 direction, float force)
    {
        _rigidbody.AddForce(direction *  force, ForceMode.Impulse);

    }
}
