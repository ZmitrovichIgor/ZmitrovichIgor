using System;
using System.Collections;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public Action<int> OnCoinsTrigger;
    public Action<int> OnFuelChange;
    public Action<int> OnHeathChange;
    public Action<bool> FuelEnd;
    
    [field: SerializeField] public int FuelQuantity { get; set; }
    //[field: SerializeField] public int CoinsQuantity { get; private set; }
    [field: SerializeField] public int Health { get; set; }
    [field: SerializeField] public bool IsFly { get; set; }
    [field: SerializeField] public float HightReached { get; set; }
    
    private void Awake()
    {
        OnFuelChange?.Invoke(FuelQuantity);
        OnHeathChange?.Invoke(Health);
    }
    
    public IEnumerator FuelCounter()
    {
        if (FuelQuantity > 0)
        {
            yield return new WaitForSeconds(1);
            --FuelQuantity;
            OnFuelChange?.Invoke(FuelQuantity);
            StartCoroutine(FuelCounter());   
        }
        else
        {
            HightReached = gameObject.transform.position.y;
            IsFly = false;
            FuelEnd?.Invoke(true);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out Coin coin))
        {
            //CoinsQuantity += coin.Value;
            OnCoinsTrigger?.Invoke(coin.Value);
        }
        if (collider.gameObject.TryGetComponent(out Fuel fuel))
        {
            FuelQuantity += fuel.Amount;
            OnFuelChange?.Invoke(FuelQuantity);
        }
        if (collider.gameObject.TryGetComponent(out Meteorite meteorite))
        {
            --Health;
            OnHeathChange?.Invoke(Health);
            if (Health == 0)
            {
                Time.timeScale = 0;
                Debug.Log("End");       
            }
            StartCoroutine(InvulnerabilityCounter(gameObject.layer, collider.gameObject.layer));
        }
    }
    
    private IEnumerator InvulnerabilityCounter(int playerLayer, int obstacleLayer)
    {
        Physics2D.IgnoreLayerCollision(playerLayer, obstacleLayer, true);
        yield return new WaitForSeconds(3);
        Physics2D.IgnoreLayerCollision(playerLayer, obstacleLayer, false);
    }
}
