using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [field: SerializeField] public ItemType Item { get; private set; }

    public void RandomItem()
    {
        var type = Enum.GetValues(typeof(ItemType));
        int randomType = Random.Range(0, type.Length);
        Item = (ItemType)randomType;
    }
}

