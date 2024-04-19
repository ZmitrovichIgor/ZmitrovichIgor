using System.Collections.Generic;
using UnityEngine;

public class PauseService : MonoBehaviour
{
    [SerializeField] private Rocket _rocket;
    [SerializeField] private GameObject _shopPanel;

    private void Awake()
    {
        _rocket.FuelEnd += CheckState;
    }

    private void CheckState(bool fuelEnd)
    {
        if (fuelEnd)
        {
            Pause();
        }
        else
        {
            Resum();
        }
    }
    
    private void Pause()
    {
        Time.timeScale = 0;
        Debug.Log("End");
        _shopPanel.SetActive(true);
    }

    public void Resum()
    {
        Time.timeScale = 1;
        Debug.Log("Start");
        _shopPanel.SetActive(false);
    }
}
