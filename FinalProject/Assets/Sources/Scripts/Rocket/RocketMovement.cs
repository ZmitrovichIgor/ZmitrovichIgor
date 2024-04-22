using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RocketMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 2;

    private Rigidbody2D _rigidbody;
    private Rocket _rocket;
    private float _yMax = 7f;
    private float _yMin = -7f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rocket = GetComponent<Rocket>();
    }
    
    private void Update()
    {
        if (_rocket.IsPause)
            return;
        Movement();
    }
    
    private void StratFlight()
    {
        _rigidbody.velocity = Vector2.up;
        _rocket.IsFly = true;
        StartCoroutine(_rocket.FuelCounter());
    }
    
    private void Movement()
    {
        if (Input.GetKey(KeyCode.Space) && (!_rocket.IsFly))
        {
            Debug.Log("Start");
            StratFlight();
        }
        if (_rocket.IsFly)
        {
            transform.position = new Vector2(Math.Clamp(transform.position.x, _yMin, _yMax), transform.position.y);
            _rigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") * _speed, _rigidbody.velocity.y);
        }
    }
}
