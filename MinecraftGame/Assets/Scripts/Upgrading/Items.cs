using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item")]
public class Items : ScriptableObject
{
    public string ItemName;
    public int ItemID;
    public Sprite ItemSprite;
}
