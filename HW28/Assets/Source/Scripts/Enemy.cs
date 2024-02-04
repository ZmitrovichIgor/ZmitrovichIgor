using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{   
    [field: SerializeField] public EnemyType Type { get; private set; }
    [field: SerializeField] public int Health { get; private set; }

    public Enemy(EnemyType type, int health)
    {
        Type = type;
        Health = health;
    }

    public Enemy RandomType()
    {
        var type = Enum.GetValues(typeof(EnemyType));
        int randomType = Random.Range(0, type.Length);
        Type = (EnemyType)randomType;
        
        return this;
    }

    public Enemy RandomHealth()
    {
        Health = Random.Range(10, 30);
        
        return this;
    }
}

public enum EnemyType
{
    Archer,
    Knight,
    Wizard,
    Homeless
}