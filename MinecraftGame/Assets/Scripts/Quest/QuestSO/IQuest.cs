using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IQuest
{
    string QuestName { get;}
    string QuestDescription { get;}
    RequirementsDictionary RequirementsDictionary { get;}
}

public interface IMainQuest : IQuest
{
    string QuestAuthor { get;}

    int QuestId { get;}

    int RewardType { get; }
}
