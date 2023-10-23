using UnityEngine;

public class MyMoney : MonoBehaviour
{

    [SerializeField] private int _myMoney;

    void Start()
    {
        //void GetMoney()
    }

    public void GetMoney(int giveMoney)
    {
        //_myMoney += giveMoney;
        if (_myMoney + giveMoney < _myMoney)
        {
            Debug.Log("У меня недостаточно денег!");
        }
        else
        {
            Debug.Log(_myMoney += giveMoney);
        }
    }

}

