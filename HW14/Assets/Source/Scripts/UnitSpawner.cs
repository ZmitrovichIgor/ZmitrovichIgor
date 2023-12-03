using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(UnitFabrica))]

public class UnitSpawner : MonoBehaviour
{
    private UnitFabrica _fabrica;
    private List<Unit> _units = new List<Unit>();
    private Material _unitMaterial;

    private void Awake()
    {
        _fabrica = GetComponent<UnitFabrica>();
        _unitMaterial = Resources.Load<Material>("UnitMaterial");
    }

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 randomPosition = transform.position + new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
            _units.Add(_fabrica.CreateUnit(randomPosition, transform));
        }
        StartCoroutine(ColorTick());
        StartCoroutine(MoveTick());
    }

    private IEnumerator MoveTick()
    {
        foreach (Unit unit in _units)
        {
            yield return new WaitForSeconds(Random.Range(0.5f, 2));
            unit.Move(transform.forward);
        }
        StartCoroutine(MoveTick());
    }

    private void ChangeColor()
    {
        _unitMaterial.color = new Color(Random.value, Random.value, Random.value, 1);
        StartCoroutine(ColorTick());
    }

    private IEnumerator ColorTick()
    {
        yield return new WaitForSeconds(Random.Range(3, 5));
        ChangeColor();
    }
}
