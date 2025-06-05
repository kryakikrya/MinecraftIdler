using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MainQuestSystem : QuestSystem
{
    private IMainQuest _currentMainQuest;
    private int _currentQuestId = 0;

    private List<IMainQuest> _mainQuestList;
    private Inventory _inventory;
    private SwitchCurrentReward _rewardTypeSwitcher;
    private QuestUI _questUI;

    [Inject]
    private void Construct(List<IMainQuest> mainQuestList, Inventory inventory, SwitchCurrentReward switchCurrentReward, QuestUI questUI)
    {
        _mainQuestList = mainQuestList;
        _inventory = inventory;
        _rewardTypeSwitcher = switchCurrentReward;
        _questUI = questUI;
    }
    private void Start()
    {
        _currentMainQuest = _mainQuestList[_currentQuestId];
        ChangeUI();
    }
    public override void ChangeUI()
    {
        _questUI.ChangeQuestUI(_currentMainQuest);
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
        RewardSystem _reward = _rewardTypeSwitcher.GetRewardType(_currentMainQuest);
        _reward.GetReward();
        _currentQuestId++;
        if (_currentQuestId <= _mainQuestList.Count)
        {
            ChangeUI();
        }
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