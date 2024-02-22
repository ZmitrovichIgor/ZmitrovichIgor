using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;


public class Spawner : MonoBehaviour
{
    [FormerlySerializedAs("_gameTime")] [SerializeField] private float _enemyQuantity = 30;
    
    private Enemy _enemy;
    private Vector2 _randomPosition;

    private void Awake()
    {
        _enemy = Resources.Load<Enemy>("Enemy");
    }

    private void Start()
    {
        StartCoroutine(CreateEnemy());
    }

    private IEnumerator CreateEnemy()
    {
        for (int i = 0; i < _enemyQuantity; i--)
        {
            yield return new WaitForSeconds(5);
            Spawn();    
        } 
    }
    
    private void Spawn()
    {
        float randomY = Random.Range(-4, 4);
        _randomPosition = new Vector2(10, randomY);

        Instantiate(_enemy, _randomPosition, Quaternion.identity);
    }
}
