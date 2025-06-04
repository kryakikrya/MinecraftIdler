using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class IncreaseSharpnessMaxLevel : RewardSystem
{

    private Sharpness _sharpness;

    [Inject]
    private void Construct(Sharpness sharpness)
    {
        _sharpness = sharpness;
    }
    public override void GetReward()
    {
        _sharpness.IncreaseMaxLvl(2); // const
    }
}