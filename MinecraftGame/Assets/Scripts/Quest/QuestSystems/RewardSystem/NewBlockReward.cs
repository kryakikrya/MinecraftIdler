using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

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
            _addNewBlocks.AddNewBlock(_newBlock, _newBlock.Chance, _newBlock.NeedToIncreaseOreChance, _newBlock.IncreasingValue);
        }
    }
}