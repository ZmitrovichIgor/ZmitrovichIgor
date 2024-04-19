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
    private IPause _pauseImplementation;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rocket = GetComponent<Rocket>();
        _rocket.IsFly = false;
    }
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && (!_rocket.IsFly))
        {
            StratFlight();
            //StartCoroutine(FuelCounter());
        }
        if (_rocket.IsFly)
        {
            Movement();
        }
    }
    
    private void StratFlight()
    {
        _rigidbody.velocity = Vector2.up;
        _rocket.IsFly = true;
        _rocket.FuelEnd?.Invoke(false);
        StartCoroutine(_rocket.FuelCounter());
    }
    
    private void Movement()
    {
        transform.position = new Vector2(Math.Clamp(transform.position.x, _yMin, _yMax), transform.position.y);
        _rigidbody.velocity = new Vector2(Input.GetAxis("Horizontal")* _speed, _rigidbody.velocity.y);
    }
}
