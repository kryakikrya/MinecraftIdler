using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ShopUpgradingWeapon : MonoBehaviour
{
    [SerializeField] private int _buff;
    [SerializeField] private List<int> _costs;

    [Header("List of materials for upgrade (max 3) number of price tags = number of IDs")]
    [SerializeField] private List<int> _materialsIDList;

    [Space]
    private Inventory _inventory;
    private Upgrade _damage;

    [Inject]
    private void Construct(Inventory inventory, Upgrade damage)
    {
        _inventory = inventory;
        _damage = damage;
    }

    public void UpgradeWeapon()
    {
        for (int i = 0;  i < _materialsIDList.Count - 1; i++)
        {
            if (_inventory.CheckInventory(_materialsIDList[i], _costs[i]))
            {
                _inventory.RemoveFromInventory(_materialsIDList[i], _costs[i]);
                _damage.IncreaseDamage(_buff);
                Debug.Log(_damage.GetDamageValue());
            }
        }
    }
    public List<int> GetMaterialsIDList()
    {
        return _materialsIDList;
    }
    public List<int> GetCostsList()
    {
        return _costs;
    }
}
