using UnityEngine;


public class PlayerRotate : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _rotate;
    [SerializeField] private float _claimX, _claimY; // ограничения по осям х и у
    

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); // считывается управление
        float vertical = Input.GetAxis("Vertical"); // считывается управление

        _rotate += new Vector3(-vertical, horizontal, 0) * _speed; // к вектору цифру угла и унможаем на скорость
        _rotate.x = Mathf.Clamp(_rotate.x, -_claimX, _claimX); // ограничение по оси х через матиматическую библиотеку
        _rotate.y = Mathf.Clamp(_rotate.y, -_claimY, _claimY); // ограничение по оси у через матиматическую библиотеку

        transform.rotation = Quaternion.Euler(_rotate); // изменяем позицию

    }
}
