using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Meteorite : MonoBehaviour
{
    [SerializeField] private int _speed = 1;

    private Rigidbody2D _rigidbody;
    private int _lifetime = 10;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Movement();
        StartCoroutine(Destroy());
    }
    
    private void Movement()
    {
        _rigidbody.velocity = Vector2.down * _speed;
    }
    
    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(_lifetime);
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out Rocket rocket))
        {
            Destroy(gameObject);
        }
    }
    
}
