using UnityEngine;

public class GiveMoney : MonoBehaviour
{
    [SerializeField] private MyMoney myMoney;
    [SerializeField] private int _giveMoney;
    private void Start()
    {

        myMoney.GetMoney(_giveMoney);

    }
}