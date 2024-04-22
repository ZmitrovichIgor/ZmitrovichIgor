using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveService : MonoBehaviour
{
    public Action OnSave;
    
    private string _filePath;
    
   
}

[Serializable]
public class SaveData
{
    public int FuelQuantity;
    public int Health;
    public int CoinsQuantity;
    public float HightReached;
    
    public SaveData(int fuelQuantity, int health, int coinsQuantity, float hightReached)
    {
        FuelQuantity = fuelQuantity;
        Health = health;
        CoinsQuantity = coinsQuantity;
        HightReached = hightReached;
    }
}

