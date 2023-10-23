using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMoney : MonoBehaviour
{
    [SerializeField] private MyMoney myMoney;
    [SerializeField] private int _getMoney;

    public void OnButtonGet()
    {
        myMoney.OperationWithMoney(_getMoney);
    }
}
