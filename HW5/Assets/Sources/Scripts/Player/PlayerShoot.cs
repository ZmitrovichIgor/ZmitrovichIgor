using System.Collections;
using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Ball _ball; // ������ �� �������
    [SerializeField] private Transform _spawnPoint; // ����� ���������
    [SerializeField] private float _shootDelay;
    [SerializeField] private float _delay;
    [SerializeField] private TextMeshProUGUI _BallCounter;
    private int _maxBall = 10;
    private bool _canShoot = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _canShoot == true) // ������� ����� ������ ������
        {
            StartCoroutine(ShootTick()); // ������ ��������
        }
        if (Input.GetKeyDown(KeyCode.R) && _canShoot == false)
        {
            Debug.Log("Recharge!");
            StartCoroutine(Delay());
        }
    }

    private void CreateBall()
    {
        if (_maxBall > 0)
        {
            _maxBall --;
            Ball ballCreated = Instantiate(_ball, _spawnPoint.position, Quaternion.identity).GetComponent<Ball>(); // �������� ������ � ����������
            ballCreated.Fly(_spawnPoint.transform.forward, 5); // ����������� �������
            _BallCounter.text = "Your ball: " + _maxBall.ToString();
        }
        else
        {
            _BallCounter.text = "Press R to reload.";
            _canShoot = false;
        }
    }

    private IEnumerator ShootTick() // ��������
    {
        yield return new WaitForSeconds(_shootDelay); // ����� �� �������� ����� �����
        CreateBall();
    }
    private IEnumerator Delay() // ��������
    {
        yield return new WaitForSeconds(_delay); // ����� �� �������� ����� �����
        _canShoot = true;
        _maxBall = 10;
        _BallCounter.text = "Your ball: " + _maxBall.ToString();
    }
}
