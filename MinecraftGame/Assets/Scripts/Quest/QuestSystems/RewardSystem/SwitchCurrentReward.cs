using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class SwitchCurrentReward : MonoBehaviour
{
    [SerializeField] private AddExpirience _addExpirience;
    [SerializeField] private IncreaseFortuneMaxLevel _increaseFortuneMaxLevel;
    [SerializeField] private IncreaseSharpnessMaxLevel _increaseSharpnessMaxLevel;
    [SerializeField] private NewBlockReward _newBlockReward;
    [SerializeField] private UnlockExpirience _unlockExpirience;
    [SerializeField] private UnlockMenu _unlockMenu;
    public RewardSystem GetRewardType(IMainQuest _quest)
    {
        switch (_quest.RewardType)
        {
            case 0:
                return _addExpirience;
            case 1:
                return _increaseFortuneMaxLevel;
            case 2:
                return _increaseSharpnessMaxLevel;
            case 3:
                return _newBlockReward;
            case 4:
                return _unlockExpirience;
            case 5:
                return _unlockMenu;
        }
        return _addExpirience;
    }
}
