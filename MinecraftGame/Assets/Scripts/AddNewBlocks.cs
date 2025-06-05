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
    private List<int> _chancesList;
    private Generation _generation;

    [Inject]
    private void Construct(List<Block> blocksList, int oreChance, List<int> chansesList, Generation generation)
    {
        _blocksList = blocksList;
        _oreChance = oreChance;
        _chancesList = chansesList;
        _generation = generation;
    }

    public void AddNewBlock(Block _newBlock, int _chance, bool _needToIncreaseOreChance = false, int _increaseOreChance = 0)
    {
        _blocksList.Add(_newBlock);
        _generation.AddNewChance(_chance);
        if (_needToIncreaseOreChance)
        {
            _generation.IncreaseOreChance(_increaseOreChance);
        }
    }
}