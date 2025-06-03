using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Main Quest")]

[Serializable]
public class MainQuest : ScriptableObject, IMainQuest
{
    public string QuestName { get => _questName; }
    [SerializeField] private string _questName;
    public string QuestDescription { get => _questDescription; }
    [SerializeField] private string _questDescription;
    public string QuestAuthor { get => _questAuthor;}
    [SerializeField] private string _questAuthor;
    public int QuestId { get => _questId;}
    [SerializeField] private int _questId;
    public RequirementsDictionary RequirementsDictionary { get => _requirementsDictionary;} // id and cost
    [SerializeField] private RequirementsDictionary _requirementsDictionary;
}

[CreateAssetMenu(fileName = "New Side Quest")]

public class SideQuest : ScriptableObject, IQuest
{
    public string QuestName { get => _questName;}
    [SerializeField] private string _questName;
    public string QuestDescription { get => _questDescription;}
    [SerializeField] private string _questDescription;
    public RequirementsDictionary RequirementsDictionary { get => _requirementsDictionary; } // id and cost
    [SerializeField] private RequirementsDictionary _requirementsDictionary;
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

    public KeyValuePair<int, int> GetRequirementById(int id)
    {
        QuestRequirements questRequirement = _questRequirement[id];
        KeyValuePair<int, int> answer = KeyValuePair.Create(questRequirement.GetMaterialID(), questRequirement.GetCost());
        return answer;
    }
    public int Count()
    {
        return _questRequirement.Count;
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