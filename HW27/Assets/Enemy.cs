using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Id;

    private void Awake()
    {
        Id = Random.Range(0, 100);
    }

    public void Die()
    {
        Destroy(gameObject);
    }
    
}
