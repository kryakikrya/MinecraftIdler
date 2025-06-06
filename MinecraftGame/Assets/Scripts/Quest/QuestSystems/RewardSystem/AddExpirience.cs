using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AddExpirience : RewardSystem
{
    private Expirience _expirience;
    private int _addExp = 100;

    [Inject]
    private void Construct(Expirience expirience)
    {
        _expirience = expirience;
    }
    public override void GetReward()
    {
        _expirience.IncreaseExpirience(_addExp);
        _addExp += 150;
    }
}