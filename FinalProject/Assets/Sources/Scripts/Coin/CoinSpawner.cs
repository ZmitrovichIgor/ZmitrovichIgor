using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Rocket _rocket;
    
    private Coin _coin;
    private float _spawnTime = 3f;
    private float _maxX = 6f;
    private float _minX = -6f;
    private float _addedDistance = 10f;
    
    private void Awake()
    {
        _coin = Resources.Load<Coin>("Coin");
    }
    
    public void StartSpawn(Rocket rocket)
    {
        _rocket = rocket;
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(_spawnTime);
        Vector2 randomPosition = new Vector2(Random.Range(_minX, _maxX), _rocket.transform.position.y + _addedDistance);
        Instantiate(_coin, randomPosition, Quaternion.identity);
        StartCoroutine(Spawn());
    }
}

