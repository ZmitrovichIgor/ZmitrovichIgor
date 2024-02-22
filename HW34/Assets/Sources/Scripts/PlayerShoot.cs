using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Transform _bulletSpawnPoint;
    
    private Bullet _bullet;
    
    private void Start()
    {
        _bullet = Resources.Load<Bullet>("Bullet");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_bullet, _bulletSpawnPoint.position, Quaternion.identity);
        }
    }
}
