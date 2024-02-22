using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]  private float _speed = 5;
    
    private Rigidbody2D _rigidbody;
    private Vector2 _playerDirection;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float directionY = Input.GetAxis("Vertical");
        _playerDirection = new Vector2(0, directionY).normalized;
        _rigidbody.velocity = new Vector2(0, _playerDirection.y * _speed);
    }
}
