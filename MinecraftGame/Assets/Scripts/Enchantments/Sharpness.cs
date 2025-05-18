using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Sharpness : MonoBehaviour
{
    [SerializeField] private int _modifierBuff;
    [SerializeField] private int _cost; // cost in levels (not exp)

    [Space]
    private Expirience _levelSystem;
    private Upgrade _damage;

    [Inject]
    private void Construct(Expirience levelSystem, Upgrade damage)
    {
        _levelSystem = levelSystem;
        _damage = damage;
    }

    public void EnchantWeapon()
    {
        if (_levelSystem.GetLevel() > _cost)
        {
            _levelSystem.LevelDown(_cost);
            _damage.IncreaseModifier(_modifierBuff);
            _modifierBuff++;
            _cost *= 2;
        }
    }

    public int GetCost()
    {
        return _cost;
    }
}
