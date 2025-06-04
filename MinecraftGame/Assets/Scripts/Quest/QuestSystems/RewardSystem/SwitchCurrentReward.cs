using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class SwitchCurrentReward : MonoBehaviour
{
    [SerializeField] List<RewardSystem> _rewardTypes = new List<RewardSystem>();
    public RewardSystem GetRewardType(IMainQuest _quest)
    {
        switch (_quest.RewardType)
        {
            case 0:
                return _rewardTypes[0];
            case 1:
                return _rewardTypes[1];
            case 2:
                return _rewardTypes[2];
            case 3:
                return _rewardTypes[3];
            case 4:
                return _rewardTypes[4];
            case 5:
                return _rewardTypes[5];
        }
        return _rewardTypes[0];
    }
}
