using UnityEngine;

public class Target : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bird>())
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value, 1);
        }
    }
}
