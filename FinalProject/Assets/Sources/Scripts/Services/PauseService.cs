using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseService : MonoBehaviour
{
    [SerializeField] private Rocket _rocket;
    [SerializeField] private GameObject _shopPanel;
    
    private void Awake()
    {
        _rocket.OnPause += CheckState;
    }

    private void CheckState(bool isPause)
    {
        if (isPause)
        {
            Pause();
        }
        else
        {
            Resum();
        }
    }
    
    public void Pause()
    {
        Time.timeScale = 0;
        Debug.Log("End");
        _rocket.IsPause = true;
        _rocket.IsFly = false;
        _shopPanel.SetActive(true);
        _rocket.transform.position = new Vector2(0, 1.45f);
    }

    public void Resum()
    {
        Time.timeScale = 1;
        Debug.Log("Start");
        _shopPanel.SetActive(false);
        _rocket.IsPause = false;
        _rocket.IsFly = false;
        _rocket.HightReached = 0;
        _rocket.CurrentFuel = _rocket.MaxFuel;
        _rocket.CurrentHealth = _rocket.MaxHealth;
        _rocket.OnFuelChange?.Invoke(_rocket.CurrentFuel);
        _rocket.OnHeathChange?.Invoke(_rocket.CurrentHealth);
    }
}
