using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Rigidbody _enemyRigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private float _force;
    [SerializeField] private Mass _mass;
    private float _enemyCount = 0;

    private void Start()
    {
        transform.localScale = new Vector3(_mass.Amount, _mass.Amount, _mass.Amount);
        Debug.Log("You mass = " + _mass.Amount);
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _rigidbody.velocity = new Vector3(0, 0, _speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _rigidbody.velocity = new Vector3(0, 0, -_speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _rigidbody.velocity = new Vector3(-_speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _rigidbody.velocity = new Vector3(_speed, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            transform.localScale = new Vector3(2, 2, 2);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Mass>())
        {
            if(_mass.Amount > collision.gameObject.GetComponent<Mass>().Amount)
            {
                _enemyRigidbody = collision.gameObject.GetComponent<Cube>();
                Vector3 normalVector = (collision.transform.position + transform.position).normalized;
                _enemyRigidbody.AddForce(normalVector * _force, ForceMode.Impulse);

                _enemyCount += 1;
                _mass.Amount += collision.gameObject.GetComponent<Mass>().Amount;
                transform.localScale = new Vector3(_mass.Amount, _mass.Amount, _mass.Amount);
                Destroy(collision.gameObject, 0.5f);
                Debug.Log("You eat = " + _enemyCount + " enemys");
                Debug.Log("+ " + collision.gameObject.GetComponent<Mass>().Amount + " mass");
                Debug.Log("You mass = " + _mass.Amount);
            }
            else
            {
                Destroy(gameObject, 0.5f);
                Debug.Log("Game over!");
            }
        }
    }
}
