using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Generation : MonoBehaviour
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

    public void Randomizer(PoolMember _poolMember)
    {
        if (Random.Range(0, 101) < _oreChance) // if < 11, then it's material (diamond, gold etc), if not, it's something like stone or earth
        {
            int _chance = Random.Range(0, 101);
            int _curChance = 0;
            for (int i = 0; i < _chansesList.Count; i++)
            {
                _curChance += _chansesList[i];
                if (_chance < _curChance)
                {
                    ChangeBlockInPool(_poolMember, _blocksList[i + 2]); // 0 and 1 for stone and dirt
                    break;
                }
            }
        }
        else
        {
            int _chance = Random.Range(0, 101);
            if (_chance < 90) ChangeBlockInPool(_poolMember, _blocksList[0]);
            else if (_chance < 101) ChangeBlockInPool(_poolMember, _blocksList[1]);
        }
    }
    public void ChangeBlockInPool(PoolMember _poolMember, Block _blockToCopy) // copy Scr. Object Block parameters
    {
        _poolMember.ChangeDurability(_blockToCopy.Durability);
        _poolMember.ChangeID(_blockToCopy.MaterialID);
        _poolMember.ChangeSprite(_blockToCopy.Sprite);
    }
}
