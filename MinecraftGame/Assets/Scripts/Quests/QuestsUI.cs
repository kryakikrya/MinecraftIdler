using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestsUI : MonoBehaviour
{
    [SerializeField] private Image _avatar;
    [SerializeField] private TextMeshProUGUI _text;

    public void UpdateUI(Sprite _newAvatar, string _questDescription)
    {
        _avatar.sprite = _newAvatar;
        _text.text = _questDescription;
    }
    public void ClearUI()
    {
        _avatar.sprite = null;
        _text.text = null;
    }
}
