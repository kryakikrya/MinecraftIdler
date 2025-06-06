using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Fortune : Enchantment
{
    private int _maxLevel = 3;
    private int _currentLevel;

    [SerializeField] private int _buff;
    [SerializeField] private int _cost;
    private int _fortuneModifier = 1;

    [Space]
    private Expirience _levelSystem;

    [Inject]
    private void Construct(Expirience levelSystem)
    {
        _levelSystem = levelSystem;
    }

    public void IncreaseFortune()
    {
        if (_currentLevel < _maxLevel)
        {
            _levelSystem.LevelDown(_cost);
            _fortuneModifier += _buff;
            _buff++;
            _cost += 10;
            print("Increase Fortune");
        }
    }

    public int GetFortuneModifier()
    {
        return _fortuneModifier;
    }
    public int GetCost()
    {
        return _cost;
    }

    public override void IncreaseMaxLvl(int lvl)
    {
        _maxLevel += lvl;
    }
}
