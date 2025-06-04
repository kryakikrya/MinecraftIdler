using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class IncreaseFortuneMaxLevel : RewardSystem
{

    private Fortune _fortune;

    [Inject]
    private void Construct(Fortune fortune)
    {
        _fortune = fortune;
    }
    public override void GetReward()
    {
        _fortune.IncreaseMaxLvl(2); // const
    }
}
