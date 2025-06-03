using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IQuest
{
    string QuestName { get;}
    string QuestDescription { get;}
    RequirementsDictionary RequirementsDictionary { get;}

}

interface IMainQuest : IQuest
{
    string QuestAuthor { get;}

    int QuestId { get;}
}
