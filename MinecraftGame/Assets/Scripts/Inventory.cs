using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Dictionary<int, int> _inventory = new Dictionary<int, int>()
    {
        [0] = 0, // Stone
        [1] = 0, // Dirt
        [2] = 0, // Iron
        [3] = 0, // Gold
        [4] = 0, // Diamond
        [5] = 0,
        [6] = 0,
        [7] = 0,

    };
    public void PutInInventory(int _materialID, int _value)
    {
        _inventory[_materialID] += _value;
    }
    public void RemoveFromInventory(int _materialID, int _value)
    {
        _inventory[_materialID] -= _value;
    }
    public int GetMaterialValue(int _materialID)
    {
        return _inventory[_materialID];
    }
}
