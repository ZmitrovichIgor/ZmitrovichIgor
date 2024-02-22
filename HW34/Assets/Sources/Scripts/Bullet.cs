using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Bullet _createBullet;
    private Rigidbody2D _rigidbody;
    private float _bulletSpeed = 10;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.AddForce(transform.right * _bulletSpeed, ForceMode2D.Impulse);
        StartCoroutine(DestroyBullet());
    }
    
    private IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(10);
        if (gameObject != null)
            Destroy(gameObject);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name != "Player")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
    
}
