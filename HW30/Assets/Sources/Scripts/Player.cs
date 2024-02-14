using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Timer))]
[RequireComponent(typeof(Enemy))]
public class Player : MonoBehaviour
{
    [SerializeField] private Button _stone;
    [SerializeField] private Button _paper;
    [SerializeField] private Button _scissors;
    
    private ItemType _choseItem;
    private Enemy _enemy;
    private Timer _timer;
    
    private void Awake()
    {
        _paper.onClick.AddListener(() => OnButtonClick(ItemType.Paper));
        _stone.onClick.AddListener(() => OnButtonClick(ItemType.Stone));
        _scissors.onClick.AddListener(() => OnButtonClick(ItemType.Scissors));
        
        _timer = GetComponent<Timer>();
        _enemy = GetComponent<Enemy>();
    }
    
    private void OnButtonClick(ItemType playerChoice)
    {
        _choseItem = playerChoice;
        Debug.Log("Your choise: " + _choseItem);
        _timer.StartTimer();
        UpdateScreen(false);
    }

    public void CompariseItem()
    {
        Debug.Log("Enemy choise: " + _enemy.Item);

        if (_choseItem == _enemy.Item)
        {   
            Debug.Log("Draw");
        }
        else if ( _choseItem == ItemType.Scissors && _enemy.Item == ItemType.Paper ||
                 _choseItem == ItemType.Paper &&  _enemy.Item == ItemType.Stone ||
                 _choseItem == ItemType.Stone && _enemy.Item == ItemType.Scissors )
            Debug.Log("Winner");
        
        else
            Debug.Log("Losing");

        UpdateScreen(true);
    }
    
    private void UpdateScreen(bool clearScreen)
    {
        
        _paper.gameObject.SetActive(clearScreen);
        _scissors.gameObject.SetActive(clearScreen);
        _stone.gameObject.SetActive(clearScreen);
        
    }
    
}

public enum ItemType
{
    Stone,
    Paper,
    Scissors
}
