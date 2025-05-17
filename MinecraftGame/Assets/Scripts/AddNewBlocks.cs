using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AddNewBlocks : MonoBehaviour
{
    [SerializeField] NewPreset _newBlockLists;
    private List<Block> _blocksList;
    private List<int> _chansesList;
    private int _oreChance;

    [Inject]
    private void Construct(List<Block> blocksList, List<int> chansesList, int oreChance)
    {
        _blocksList = blocksList;
        _chansesList = chansesList;
        _oreChance = oreChance;
    }

    public void AddNewBlock(int ID)
    {
        _blocksList = _newBlockLists.GetChansesPreset(ID).GetNewBlockList();
    }
}

[Serializable]

public class NewPreset
{
    [SerializeField] private
    List<NewChansesPreset> _newChansesPresets;

    public NewChansesPreset GetChansesPreset(int ID)
    {
        return _newChansesPresets[ID];
    }
}

[Serializable]
public class NewChansesPreset
{
    [SerializeField] private List<Block> _newBlocksList;
    [SerializeField]  private List<int> _newChansesList;

    public List<Block> GetNewBlockList()
    {
        return _newBlocksList;
    }
    public List<int> GetNewChansesList()
    {
        return _newChansesList;
    }
}