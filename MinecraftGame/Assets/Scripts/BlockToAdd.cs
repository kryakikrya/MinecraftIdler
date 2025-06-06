using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Block To Add")]
public class BlockToAdd : Block
{
    public bool NeedToIncreaseOreChance;
    public int IncreasingValue;
    public int Chance;
}