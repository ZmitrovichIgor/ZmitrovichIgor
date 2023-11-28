using System.Collections;
using UnityEngine;

public class SlingshotAmmo : MonoBehaviour
{
    [SerializeField] private float _maxAmmo = 5;
    [SerializeField] private float _delay = 1;
    [SerializeField] private ShotPoint _point;
    [SerializeField] private BirdsFactory _factory;
    [SerializeField] private Transform _shootPosition;
    [SerializeField] private Transform _startPosition;
    private float _currentAmmo;

    private void Awake()
    {
        _currentAmmo = _maxAmmo;
        NextBird();
        _point.OnRealeaseShot += NextBird;
    }

    private void NextBird()
    {
        if (_currentAmmo <= 0)
            return;
        _currentAmmo--;
        StartCoroutine(ReloadDelay());
    }

    private void CreateBird()
    {
        Bird newBird = _factory.CreateBird(_startPosition.position);
        newBird.Setup(_shootPosition, _startPosition);
        _point.UpdateBird(newBird);
    }

    private IEnumerator ReloadDelay()
    {
        yield return new WaitForSeconds(_delay);
        CreateBird();
    }
}
