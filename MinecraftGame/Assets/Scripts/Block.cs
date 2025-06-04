using System.Security.Cryptography.X509Certificates;
using UnityEngine;

[CreateAssetMenu(fileName = "New Block")]
public class Block : ScriptableObject
{
    public string BlockName;
    public int MaterialID;
    public double Durability;
    public float Expirience;
    public Sprite Sprite;
    public Sprite ItemSprite;
}

[CreateAssetMenu(fileName = "Block To Add")]
public class BlockToAdd : Block
{
    public bool NeedToIncreaseOreChance;
    public int IncreasingValue;
}