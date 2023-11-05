using TMPro;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int _count;
    [SerializeField] private TextMeshProUGUI _counter;



    private void OnCollisionEnter(Collision collision) // функция столкновения
    {
        if (collision.gameObject.GetComponent<Ball>()) // когда объект сталкивается с шаром
        { 
            _count++;
            _counter.text = "Count: " + _count.ToString();
            Destroy(collision.gameObject);
        }
    }
}
