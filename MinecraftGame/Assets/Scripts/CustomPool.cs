using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CustomPool : MonoBehaviour
{
    [SerializeField] private List<PoolMember> _pool = new List<PoolMember>();
    [SerializeField] private Global _world;


    private void Start()
    {
        List<Block> _blockList = _world.GetBlockList();
        for (int i = 0; i < _pool.Count - 1; i++) // go through the list of pool elements
        {
            Randomizer(_pool[i]);
        }
    }
    public void RandomBlocks()
    {
        for (int i = 0; i < _pool.Count - 1; i++) // go through the list of pool elements
        {
            _pool[i].gameObject.SetActive(true);
            Randomizer(_pool[i]);
        }
    }

    public void Randomizer(PoolMember _poolMember)
    {
        if (Random.Range(0, 101) < 21) // if < 11, then it's material (diamond, gold etc), if not, it's something like stone or earth
        {
            int _chance = Random.Range(0, 101);
            int _curChance = 0;
            for (int i = 0; i < _world.GetChancesList().Count; i++)
            {
                _curChance += _world.GetChancesList()[i];
                if (_chance < _curChance)
                {
                    ChangeBlockInPool(_poolMember, _world.GetBlockList()[i + 2]); // 0 and 1 for stone and dirt
                    break;
                }
            }
        }
        else
        {
            int _chance = Random.Range(0, 101);
            if (_chance < 90) ChangeBlockInPool(_poolMember, _world.GetBlockList()[0]);
            else if (_chance < 101) ChangeBlockInPool(_poolMember, _world.GetBlockList()[1]);
        }
    }

    public void ChangeBlockInPool(PoolMember _poolMember, Block _blockToCopy) // copy Scr. Object Block parameters
    {
        _poolMember.ChangeDurability(_blockToCopy.Durability);
        _poolMember.ChangeID(_blockToCopy.MaterialID);
        _poolMember.ChangeSprite(_blockToCopy.Sprite);
    }
}
