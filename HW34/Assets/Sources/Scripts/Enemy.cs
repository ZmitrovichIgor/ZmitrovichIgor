
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    private float _lifeTime = 10;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.AddForce(-transform.right * _speed, ForceMode2D.Impulse); 
        StartCoroutine(DestroyEnemy());
    }

    private IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(_lifeTime);
        if (gameObject != null)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(collision.gameObject);
        }
    }
}
