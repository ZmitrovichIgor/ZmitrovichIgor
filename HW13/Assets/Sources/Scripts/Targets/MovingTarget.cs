using DG.Tweening;
using System.Collections;
using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    private Vector2 _startPosition;
    private Vector2 _endPosition;
    private bool _toUp = true;
    [SerializeField] private float _delay = 2;

    private void Awake()
    {
        _startPosition = transform.position;
        StartCoroutine(MoveDelay());
    }

    private void ChangePosition()
    {
        transform.DOMove(_endPosition, _delay);
        StartCoroutine(MoveDelay());
    }

    private IEnumerator MoveDelay()
    {
        if (_toUp)
        {
            _endPosition = _startPosition + new Vector2(_startPosition.x, _startPosition.y + 3);
            _toUp = false;
        }
        else
        {
            _endPosition = _startPosition + new Vector2(_startPosition.x, _startPosition.y - 3);
            _toUp = true;
        }
        yield return new WaitForSeconds(2);
        ChangePosition();
    }

}
