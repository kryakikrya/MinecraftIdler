using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class RewardSystem
{
    public abstract void GetReward();
}

public class NewBlockReward : RewardSystem
{

    private AddNewBlocks _addNewBlocks;
    private List<BlockToAdd> _blocksToAdd;
    private int _currentBlockId = 0;

    [Inject]
    private void Construct(AddNewBlocks addNewBlocks, List<BlockToAdd> blocksToAdd)
    {
        _addNewBlocks = addNewBlocks;
        _blocksToAdd = blocksToAdd;
    }
    public override void GetReward()
    {
        if (_currentBlockId <= _blocksToAdd.Count)
        {
            BlockToAdd _newBlock = _blocksToAdd[_currentBlockId];
            _addNewBlocks.AddNewBlock(_newBlock, _newBlock.NeedToIncreaseOreChance, _newBlock.IncreasingValue);
        }
    }
}

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

public class IncreaseMaxLevelOfEnchantment : RewardSystem
{
    public override void GetReward()
    {

    }
}