using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Rocket _rocket;
    
    private CoinSpawner _coinSpawner;
    private FuelSpawner _fuelSpawner;
    private MeteoriteSpawner _meteoriteSpawner;

    private void Awake()
    {
        _coinSpawner = GetComponent<CoinSpawner>();
        _fuelSpawner = GetComponent<FuelSpawner>();
        _meteoriteSpawner = GetComponent<MeteoriteSpawner>();
    }
    
    private void Start()
    {
        StarGame();
    }

    private void StarGame()
    {
        _coinSpawner.StartSpawn(_rocket);
        _fuelSpawner.StartSpawn(_rocket);
        _meteoriteSpawner.StartSpawn(_rocket);
    }
}
