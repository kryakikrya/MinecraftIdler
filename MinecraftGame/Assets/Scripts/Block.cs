using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

[CreateAssetMenu(fileName = "New Block")]
public class Block : ScriptableObject
{
    public string BlockName;
    public int MaterialID;
    public double Durability;
    public Sprite Sprite;
}
