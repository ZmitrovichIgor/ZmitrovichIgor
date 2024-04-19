using System.Collections;
using UnityEngine;

public class MeteoriteSpawner : MonoBehaviour
{
    [SerializeField] private Rocket _rocket;
    
    private Meteorite _meteorite;
    private float _spawnTime = 8f;
    private float _maxX = 6f;
    private float _minX = -6f;
    private float _addedDistance = 7f;

    private void Awake()
    {
        _meteorite = Resources.Load<Meteorite>("Meteorite");
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
        Instantiate(_meteorite, randomPosition, Quaternion.identity);
        StartCoroutine(Spawn());
    }
}
