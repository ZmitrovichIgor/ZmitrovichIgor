using System.Collections;
using UnityEngine;

public class FuelSpawner : MonoBehaviour
{
    [SerializeField] private Rocket _rocket;

    private Fuel _fuel;
    private float _spawnTime = 15f;
    private float _maxX = 6f;
    private float _minX = -6f;
    private float _addedDistance = 10f;

    private void Awake()
    {
        _fuel = Resources.Load<Fuel>("Fuel");
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
        Instantiate(_fuel, randomPosition, Quaternion.identity);
        StartCoroutine(Spawn());
    }
}
