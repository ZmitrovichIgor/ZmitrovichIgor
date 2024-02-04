using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(EnemyFactory))]
public class EnemySpawner : MonoBehaviour
{
   [field: SerializeField] private List<Enemy> _enemies;
   [field: SerializeField] private List<Enemy> _archerEnemies;
   [field: SerializeField] private List<Enemy> _knightEnemies;
   [field: SerializeField] private List<Enemy> _wizardEnemies;
   [field: SerializeField] private List<Enemy> _homelessEnemies;
   
   [SerializeField] private int _enemyQuantity = 5;

   private EnemyFactory _enemyFactory;
   private Coroutine _spawn;
   private int _enemyTick;

   private void Awake()
   {
      _enemyFactory = GetComponent<EnemyFactory>();
   }

   private void Start()
   {
      StartCoroutine(Spawn());
   }

   private IEnumerator Spawn()
   {
      for (_enemyTick = 1; _enemyTick <= _enemyQuantity; _enemyTick++)
      {
         yield return new WaitForSeconds(2);
         CreateEnemy();
         SortEnemy();
      }
   }

   private void CreateEnemy()
   {
      Vector3 position = new Vector3(Random.Range(11, -11), 0.55f, Random.Range(11, -11));
      Enemy createdEnemy = _enemyFactory.EnemyCreated(position);
      
      _enemies.Add(createdEnemy);
   }

   private void SortEnemy()
   {
      _archerEnemies = _enemies.Where(enemy => enemy.Type == EnemyType.Archer).ToList();
      _knightEnemies = _enemies.Where(enemy => enemy.Type == EnemyType.Knight).ToList();
      _wizardEnemies = _enemies.Where(enemy => enemy.Type == EnemyType.Wizard).ToList();
      _homelessEnemies = _enemies.Where(enemy => enemy.Type == EnemyType.Homeless).ToList();
   }
}
