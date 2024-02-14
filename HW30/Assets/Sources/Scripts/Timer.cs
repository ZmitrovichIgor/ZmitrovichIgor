using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private Enemy _enemy;
    private Player _player;
    private int _delayTime = 3;
    
    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _player = GetComponent<Player>();
    }

    public void StartTimer()
    {
        StartCoroutine(TimerTick());
    }
    
    private IEnumerator TimerTick()
    {
        while (_delayTime>0)
        {
            yield return new WaitForSeconds(1);
            Debug.Log(_delayTime);
            _delayTime--;
        }
        _enemy.RandomItem();
        _player.CompariseItem();
        
    }
}
