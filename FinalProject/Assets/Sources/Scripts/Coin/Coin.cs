using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Coin : MonoBehaviour
{
    [field: SerializeField] public int Value { get; private set; }

    private int _lifetime = 10;
    
    private void Awake()
    {
        Value = Random.Range(1, 3);
        StartCoroutine(Destroy());
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
