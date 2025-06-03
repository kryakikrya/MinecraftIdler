using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestSystem : MonoBehaviour
{

    public abstract void ChangeUI();
    public abstract void CompleteQuest();
    public abstract void GiveReward();

}
