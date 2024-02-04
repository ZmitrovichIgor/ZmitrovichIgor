using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    private Enemy _enemy;
    
    public void Awake()
    {
        _enemy = Resources.Load <Enemy> ("Enemy");
    }

    public Enemy EnemyCreated(Vector3 position)
    {
        Enemy enemy = Instantiate(_enemy, position, Quaternion.identity).RandomType().RandomHealth();

        return enemy;
    }
}
