using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dependencyinjection : MonoBehaviour
{
    [SerializeField] private List<Block> _blocksList;
    public List<Block> GetBlockList()
    {
        return _blocksList;
    }
}
