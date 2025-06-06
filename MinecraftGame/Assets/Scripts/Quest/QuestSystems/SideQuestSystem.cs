using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SideQuestSystem : QuestSystem
{
    private SideQuest _currentSideQuest;
    private bool _isPossible;

    private List<SideQuest> _sideQuestsList;
    private Inventory _inventory;
    private AddExpirience _addExpirience;
    private List<Block> _blocksList;
    [SerializeField] private QuestUI _sideQuestUI;

    [Inject]
    private void Construct(List<SideQuest> sideQuestsList, Inventory inventory, AddExpirience addExpirience, List<Block> blocksList)
    {
        _sideQuestsList = sideQuestsList;
        _inventory = inventory;
        _addExpirience = addExpirience;
        _blocksList = blocksList;
    }
    private void Start()
    {
        RandomQuest();
        ChangeUI();
    }

    private void RandomQuest()
    {
        int iterations = 0;
        _currentSideQuest = _sideQuestsList[Random.Range(0, _sideQuestsList.Count)];
        while (IsPossible(_currentSideQuest.RequirementsDictionary) == false && iterations < 20)
        {
            RandomQuest();
            return;
        }
        _currentSideQuest = _sideQuestsList[0];
    }
    private bool IsPossible(RequirementsDictionary _requirementsDictionary)
    {
        for (int i = 0; i < _requirementsDictionary.Count(); i++)
        {
            if (_blocksList.Count > _requirementsDictionary.GetRequirementById(i).Key)
            {
                return false;
            }
        }
        return true;
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
        RandomQuest();
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
