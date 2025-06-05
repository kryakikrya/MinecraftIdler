using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SideQuestSystem : QuestSystem
{
    private IQuest _currentSideQuest;

    private List<IQuest> _sideQuestsList;
    private Inventory _inventory;
    private AddExpirience _addExpirience;
    private QuestUI _sideQuestUI;

    [Inject]
    private void Construct(List<IQuest> sideQuestsList, Inventory inventory, AddExpirience addExpirience, QuestUI sideQuestUI)
    {
        _sideQuestsList = sideQuestsList;
        _inventory = inventory;
        _addExpirience = addExpirience;
        _sideQuestUI = sideQuestUI;
    }
    private void Start()
    {
        _currentSideQuest = _sideQuestsList[Random.Range(0, _sideQuestsList.Count + 1)];
        ChangeUI();
    }

    public override void ChangeUI()
    {
        _sideQuestUI.ChangeQuestUI(_currentSideQuest);
    }
    public override void CompleteQuest()
    {
        RequirementsDictionary _requirementsDictionary = _currentSideQuest.RequirementsDictionary;
        if (CheckInventory(_requirementsDictionary))
        {
            SpendMaterials(_requirementsDictionary);
            GiveReward();
            ChangeUI();
        }
    }
    public override void GiveReward()
    {
        _addExpirience.GetReward();
        _currentSideQuest = _sideQuestsList[Random.Range(0, _sideQuestsList.Count + 1)];
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
