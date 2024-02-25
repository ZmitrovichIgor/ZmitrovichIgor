using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]  private float _speed = 5;
    
    private Rigidbody2D _rigidbody;
    private float _yMax = 4.5f;
    private float _yMin = -4.5f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.position = new Vector2(transform.position.x, Math.Clamp(transform.position.y, _yMin, _yMax));
        _rigidbody.velocity = new Vector2(0, Input.GetAxis("Vertical")) * _speed;
    }
}
