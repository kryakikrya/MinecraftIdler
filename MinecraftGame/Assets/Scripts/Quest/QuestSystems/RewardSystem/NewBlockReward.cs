using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class NewBlockReward : RewardSystem
{

    private AddNewBlocks _addNewBlocks;
    private List<BlockToAdd> _blocksToAdd;
    private int _currentBlockId = 0;
    private List<UIInventory> _uiInventory;
    private Generation _generation;

    [Inject]
    private void Construct(AddNewBlocks addNewBlocks, List<BlockToAdd> blocksToAdd, List<UIInventory> uiInventory, Generation generation)
    {
        _addNewBlocks = addNewBlocks;
        _blocksToAdd = blocksToAdd;
        _uiInventory = uiInventory;
        _generation = generation;
    }
    public override void GetReward()
    {
        if (_currentBlockId <= _blocksToAdd.Count)
        {
            BlockToAdd _newBlock = _blocksToAdd[_currentBlockId];
            _addNewBlocks.AddNewBlock(_newBlock, _newBlock.Chance, _newBlock.NeedToIncreaseOreChance, _newBlock.IncreasingValue);
            _uiInventory[_currentBlockId + 2].gameObject.SetActive(true);
            _generation.PrintGenerationInfo();
        }
    }
}