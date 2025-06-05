using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
public class QuestUI : MonoBehaviour
{
    [SerializeField] private List<Image> _imagesList;
    [SerializeField] private List<TextMeshProUGUI> _textList;
    [SerializeField] private TextMeshProUGUI _descriptionText;
    private List<Block> _blocksList;

    [Inject]
    private void Construct(List<Block> blocksList)
    {
        _blocksList = blocksList;
    }
    
    public void ChangeQuestUI(IQuest _quest)
    {
        for (int i = 0; i < _imagesList.Count; i++)
        {
            _imagesList[i].gameObject.SetActive(false);
            _textList[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < _quest.RequirementsDictionary.Count(); i++)
        {
            _imagesList[i].gameObject.SetActive(true);
            _imagesList[i].sprite = _blocksList[_quest.RequirementsDictionary.GetRequirementById(i).Key].ItemSprite;
            _textList[i].gameObject.SetActive(true);
            _textList[i].text = (_quest.RequirementsDictionary.GetRequirementById(i).Value).ToString();
        }
        _descriptionText.text = _quest.QuestDescription;
    }
}
