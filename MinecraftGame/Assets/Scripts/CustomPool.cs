using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CustomPool : MonoBehaviour
{
    [SerializeField] private List<PoolMember> _pool = new List<PoolMember>();
    [SerializeField] private Dependencyinjection _world;
    
    public void RandomBlocks()
    {
        for (int i = 0; i < _pool.Count - 1; i++) // go through the list of pool elements
        {
            List<Block> _blockList = _world.GetBlockList();
            if (Random.Range(0, 101) < 11) // if < 11, then it's material (diamond, gold etc), if not, it's something like stone or earth
            {
                int _chance = Random.Range(0, 101);
                if (_chance < 60) ChangeBlockInPool(_pool[i], _world.GetBlockList()[2]); // material chances
                else if (_chance < 80) ChangeBlockInPool(_pool[i], _world.GetBlockList()[3]);
                else if (_chance < 101) ChangeBlockInPool(_pool[i], _world.GetBlockList()[4]);
            }
            else
            {
                int _chance = Random.Range(0, 101);
                if (_chance < 90) ChangeBlockInPool(_pool[i], _world.GetBlockList()[0]);
                else if (_chance < 101) ChangeBlockInPool(_pool[i], _world.GetBlockList()[1]);
            }
        }
    }
    public void ChangeBlockInPool(PoolMember _poolMember, Block _blockToCopy) // copy Scr. Object Block parameters
    {
        _poolMember.gameObject.SetActive(true);
        _poolMember.ChangeDurability(_blockToCopy.Durability);
        _poolMember.ChangeID(_blockToCopy.MaterialID);
        _poolMember.ChangeSprite(_blockToCopy.Sprite);
    }
}
