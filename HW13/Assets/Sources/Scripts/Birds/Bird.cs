using DG.Tweening;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]

public class Bird : MonoBehaviour
{
    [SerializeField] private Transform _shotPoint;
    private Rigidbody2D _rigidbody;
    private bool _isLaunch = false;
    private bool _isCanSBoost = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.isKinematic = true;
    }

    private void Update()
    {
        if (_isLaunch) 
        {
            transform.position = _shotPoint.position;
        }
        if (_isCanSBoost && Input.GetMouseButtonDown(0))
        {
            _rigidbody.AddForce(_rigidbody.velocity * 2, ForceMode2D.Impulse);
            _isCanSBoost = false;
        }
    }

    public void Setup(Transform shotPoint, Transform startPoint) 
    {
        _shotPoint = shotPoint;
        transform.DOJump(shotPoint.position, 1f, 1, 1).OnComplete(() =>
        {
            _isLaunch = true;
        });
    }

    public void Launch(Vector2 direction)
    {
        _isLaunch = false;
        _rigidbody.isKinematic = false;
        _rigidbody.AddForce(direction, ForceMode2D.Impulse);
        _isCanSBoost = true;
    }
}
