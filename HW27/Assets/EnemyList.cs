using System.Collections.Generic;
using UnityEngine;

public class EnemyList : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies = new List<Enemy>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
            Delete(false);

        if (Input.GetKeyDown(KeyCode.F))
            Delete(true);
    }

    private void Delete(bool random)
    {
        if (random)
        {
            if (Random.Range(0, 100) <= 30)
                RemoveEnemies(Random.Range(0, _enemies.Count));    
        }
        else
        {
            for (int i = 0; i < _enemies.Count; i++)
            {
                if (_enemies[i].Id % 2 == 1)
                    RemoveEnemies(i);
            }    
        }
    }

    private void RemoveEnemies(int i)
    {
        _enemies[i].Die();
        _enemies.RemoveAt(i);
    }
}
