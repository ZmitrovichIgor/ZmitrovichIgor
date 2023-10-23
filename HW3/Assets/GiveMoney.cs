using UnityEngine;

public class GiveMoney : MonoBehaviour
{
    [SerializeField] private MyMoney myMoney;
    [SerializeField] private int _giveMoney;
    public void OnButtonGive()
    {

        myMoney.OperationWithMoney(_giveMoney);

    }
}