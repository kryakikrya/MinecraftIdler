using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UnlockMenu : RewardSystem
{
    private List<UnlockNewMenu> _unlockableMenuList;
    private int _currentMenuId = 0;

    [Inject]
    private void Construct(List<UnlockNewMenu> unlockableMenuList)
    {
        _unlockableMenuList = unlockableMenuList;
    }

    public override void GetReward()
    {
        if (_currentMenuId <= _unlockableMenuList.Count)
        {
            _unlockableMenuList[_currentMenuId].Unlock();
        }
    }
}
