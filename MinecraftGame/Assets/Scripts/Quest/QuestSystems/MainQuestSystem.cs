using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MainQuestSystem : QuestSystem
{
    private IMainQuest _currentMainQuest;

    private List<IMainQuest> _mainQuestList;
    private Inventory _inventory;

    [Inject]
    private void Construct(List<IMainQuest> mainQuestList, Inventory inventory)
    {
        _mainQuestList = mainQuestList;
        _inventory = inventory;
    }
    private void Start()
    {
        _currentMainQuest = _mainQuestList[0];
    }
    public override void ChangeUI()
    {
        
    }
    public override void CompleteQuest()
    {
        RequirementsDictionary _requirementsDictionary = _currentMainQuest.RequirementsDictionary;
        if (CheckInventory(_requirementsDictionary))
        {
            SpendMaterials(_requirementsDictionary);
            GiveReward();
        }
    }
    public override void GiveReward()
    {
        
    }
    public bool CheckInventory(RequirementsDictionary _requirementsDictionary)
    {
        for (int i = 0; i < _requirementsDictionary.Count(); i++)
        {
            if (false == _inventory.CheckInventory(_requirementsDictionary.GetRequirementById(i).Key, _requirementsDictionary.GetRequirementById(i).Value))
            {
                return false;
            }
        }
        return true;
    }
    public void SpendMaterials(RequirementsDictionary _requirementsDictionary)
    {
        for (int i = 0; i < _requirementsDictionary.Count(); i++)
        {
            _inventory.RemoveFromInventory(_requirementsDictionary.GetRequirementById(i).Key, _requirementsDictionary.GetRequirementById(i).Value);
        }
    }
}