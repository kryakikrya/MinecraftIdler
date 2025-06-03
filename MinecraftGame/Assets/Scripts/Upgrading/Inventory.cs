using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Inventory : MonoBehaviour
{
    private Fortune _fortune;

    [Inject]
    private void Construct(Fortune fortune)
    {
        _fortune = fortune;
    }

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
        _value *= _fortune.GetFortuneModifier();
        _inventory[_materialID] += _value;
    }
    public void RemoveFromInventory(int _materialID, int _value)
    {
        if (_inventory[_materialID] >= _value || CheckInventory(_materialID, _value))
        {
            _inventory[_materialID] -= _value;
        }
    }

    public bool CheckInventory(int _materialID, int _value)
    {
        return _inventory[_materialID] >= _value;
    }
    public int GetMaterialValue(int _materialID)
    {
        return _inventory[_materialID];
    }

}
