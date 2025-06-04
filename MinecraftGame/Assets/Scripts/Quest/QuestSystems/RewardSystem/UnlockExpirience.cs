using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UnlockExpirience : RewardSystem
{
    private Expirience _expirience;

    [Inject]
    private void Construct(Expirience expirience)
    {
        _expirience = expirience;
    }
    public override void GetReward()
    {
        _expirience.SetActive();
    }
}