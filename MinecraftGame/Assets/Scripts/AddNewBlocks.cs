using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AddNewBlocks : MonoBehaviour
{
    private List<Block> _blocksList;
    private int _oreChance;

    [Inject]
    private void Construct(List<Block> blocksList, int oreChance)
    {
        _blocksList = blocksList;
        _oreChance = oreChance;
    }

    public void AddNewBlock(Block _newBlock, bool _needToIncreaseOreChance = false, int _increaseOreChance = 0)
    {
        _blocksList.Add(_newBlock);
        if (_needToIncreaseOreChance)
        {
            _oreChance += _increaseOreChance;
        }
    }
}