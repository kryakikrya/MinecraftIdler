using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SideQuestSystem : QuestSystem
{
    private SideQuest _currentSideQuest;

    private List<SideQuest> _sideQuestsList;
    private Inventory _inventory;
    private AddExpirience _addExpirience;
    [SerializeField] private QuestUI _sideQuestUI;

    [Inject]
    private void Construct(List<SideQuest> sideQuestsList, Inventory inventory, AddExpirience addExpirience)
    {
        _sideQuestsList = sideQuestsList;
        _inventory = inventory;
        _addExpirience = addExpirience;
    }
    private void Start()
    {
        _currentSideQuest = _sideQuestsList[Random.Range(0, _sideQuestsList.Count)];
        ChangeUI();
    }

    public override void ChangeUI()
    {
        _sideQuestUI.ChangeSideQuestUI(_currentSideQuest);
    }
    public override void CompleteQuest()
    {
        RequirementsDictionary _requirementsDictionary = _currentSideQuest.RequirementsDictionary;
        if (CheckInventory(_requirementsDictionary))
        {
            SpendMaterials(_requirementsDictionary);
            GiveReward();
            print("Side Quest Completed!");
            ChangeUI();
        }
    }
    public override void GiveReward()
    {
        _addExpirience.GetReward();
        _currentSideQuest = _sideQuestsList[Random.Range(0, _sideQuestsList.Count)];
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
