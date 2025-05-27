using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(QuestsUI))]
public class QuestSystem : MonoBehaviour
{
    private List<Quest> _quests = new List<Quest>();
    private QuestsUI _questUI;
    private int _buttonType; // 0 - Add New Block, 1 - Add new mechanic, 2 - Increase EXP
    private Quest _currentQuest;

    [Inject]
    private void Construct(List<Quest> quests, QuestsUI questsUI)
    {
        _quests = quests;
        _questUI = questsUI;
    }
    private void Start()
    {
        FindQuestByType(_buttonType);
    }
    public void OnClick()
    {

    }

    public Quest FindQuestByType(int _rewardType)
    {
        for (int i = 0;  i < _quests.Count; i++)
        {
            if (CheckType(i) == _rewardType)
            {
                return _quests[i];
            }
        }
        return null;
    }
    public int CheckType(int _id)
    {
        return _quests[_id].RewardType;
    }

    public void ChangeQuest(Quest _quest)
    {

    }
}
  