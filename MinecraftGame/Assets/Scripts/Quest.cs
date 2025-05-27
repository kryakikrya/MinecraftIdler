using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest")]
public class Quest : ScriptableObject
{
    public string QuestName;
    public string QuestDescription;
    public string QuestAuthor;
    public int QuestType;
    public RequirementsDictionary _requirementsDictionary; // id and cost
}

[Serializable]

public class RequirementsDictionary
{
    [SerializeField]
    private
    List<QuestRequirements> _questRequirement;

    public Dictionary<int, int> GetChansesPreset()
    {
        Dictionary<int, int> _materialAndCostList = new Dictionary<int, int>();
        foreach (var _materialAndCost in _questRequirement)
        {
            _materialAndCostList.Add(_materialAndCost.GetMaterialID(), _materialAndCost.GetCost());
        }
        return _materialAndCostList;
    }
}

[Serializable]
public class QuestRequirements
{
    [SerializeField] private int _materialID;
    [SerializeField] private int _cost;

    public int GetMaterialID()
    {
        return _materialID;
    }
    public int GetCost()
    {
        return _cost;
    }
}