using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(ChangeShopUI))]
public class ShopUpgradingWeapon : MonoBehaviour
{
    [SerializeField] private int _buff;
    [SerializeField] private List<int> _costs;

    [Header("List of materials for upgrade (max 3) number of price tags = number of IDs")]
    [SerializeField] private List<int> _idList;
    private ChangeShopUI _shopUI;

    [Space]
    private Inventory _inventory;
    private Upgrade _damage;
    private Sharpness _sharpness;
    private Fortune _fortune;

    [Inject]
    private void Construct(Inventory inventory, Upgrade damage, Sharpness sharpness, Fortune fortune)
    {
        _inventory = inventory;
        _damage = damage;
        _fortune = fortune;
        _sharpness = sharpness;
    }
    private void Start()
    {
        _shopUI = GetComponent<ChangeShopUI>();
    }

    public void UpgradeWeapon()
    {
        for (int i = 0;  i < _idList.Count; i++)
        {
            if (_inventory.CheckInventory(_idList[i], _costs[i]))
            {
                _inventory.RemoveFromInventory(_idList[i], _costs[i]);
                _damage.IncreaseDamage(_buff);
                _costs[i] += 2;
                print(_damage + "    buff: " + _buff);
                _shopUI.UpdateUI();
            }
        }
    }

    private void IncreaseCosts()
    {
        for (int i = 0; i < _costs.Count; i++)
        {
            _costs[i] *= 2;
        }
    }
    public List<int> GetMaterialsIDList()
    {
        return _idList;
    }
    public List<int> GetCostsList()
    {
        return _costs;
    }
}
