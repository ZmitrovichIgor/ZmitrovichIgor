using UnityEngine;

public class MyMoney : MonoBehaviour
{
    [SerializeField] private int _myMoney;

    public void OperationWithMoney(int _Money)
    { 
        if (_myMoney + _Money < 0)
        {
            Debug.Log("������������ �������� �������!");
        }
        else
        {
            _myMoney += _Money;
            Debug.Log("������� �������� ������� = " + _myMoney);
        }
    }
}

