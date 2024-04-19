using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
 
    [field: SerializeField] public int BuyLife { get; private set; }
    [field: SerializeField] public float BuySpeed { get; private set; }
    [field: SerializeField] public float BuyFuel { get; private set; }
    [SerializeField] private Wallet _wallet;
    
    
    public void BuyingLife(int amount)
    {
        Debug.Log("life");
    }
    
    public void BuyingSpeed(float amount)
    {
        Debug.Log("speed");   
    }
    
    public void BuyingFuel(float amount)
    {
        Debug.Log("fuel");
    }
}
