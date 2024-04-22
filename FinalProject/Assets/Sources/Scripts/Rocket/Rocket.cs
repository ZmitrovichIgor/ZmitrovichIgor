using System;
using System.Collections;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public Action<int> OnCoinsTrigger;
    public Action<int> OnFuelChange;
    public Action<int> OnHeathChange;
    public Action<bool> OnPause;
    
    [field: SerializeField] public int CurrentFuel { get; set; }
    [field: SerializeField] public int MaxFuel { get; set; }
    [field: SerializeField] public int CurrentHealth { get; set; }
    [field: SerializeField] public int MaxHealth { get; set; }
    [field: SerializeField] public bool IsFly { get; set; }
    [field: SerializeField] public bool IsPause { get; set; }
    [field: SerializeField] public float HightReached { get; set; }

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        CurrentFuel = MaxFuel;
        CurrentHealth = MaxHealth;
        OnFuelChange?.Invoke(CurrentFuel);
        OnHeathChange?.Invoke(CurrentHealth);
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    public IEnumerator FuelCounter()
    {
        if (CurrentFuel > 0)
        {
            yield return new WaitForSeconds(1);
            --CurrentFuel;
            OnFuelChange?.Invoke(CurrentFuel);
            HightReached = gameObject.transform.position.y;
            StartCoroutine(FuelCounter());   
        }
        else
        {
            StopCoroutine(FuelCounter());
            _rigidbody.velocity = Vector2.zero;
            OnPause?.Invoke(true);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out Coin coin))
        {
            OnCoinsTrigger?.Invoke(coin.Value);
        }
        if (collider.gameObject.TryGetComponent(out Fuel fuel))
        {
            CurrentFuel += fuel.Amount;
            OnFuelChange?.Invoke(CurrentFuel);
        }
        if (collider.gameObject.TryGetComponent(out Meteorite meteorite))
        {
            --CurrentHealth;
            OnHeathChange?.Invoke(CurrentHealth);
            if (CurrentHealth == 0)
            {
                StopCoroutine(FuelCounter());
                _rigidbody.velocity = Vector2.zero;
                OnPause?.Invoke(true);
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
