using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Global : MonoBehaviour
{
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
    public List<Block> GetBlockList()
    {
        return _blocksList;
    }
    public List<int> GetChancesList()
    {
        return _chansesList;
    }
    public int GetOreChance()
    {
        return _oreChance;
    }
}
