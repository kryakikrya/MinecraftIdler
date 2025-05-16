using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Image))]
public class UIExpirience : MonoBehaviour
{
    private Expirience _levelSystem;
    private Image _image;
    [SerializeField] private List<TextMeshProUGUI> _textLevel;

    [Inject]
    private void Construct(Expirience expirience)
    {
        _levelSystem = expirience;
    }

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    public void UpdateExpirience()
    {
        _image.fillAmount = _levelSystem.GetExpirience() / _levelSystem.GetExpirienceForNextLevel();
    }

    public void UpdateLevel()
    {
        for (int i = 0; i < _textLevel.Count; i++)
        {
            _textLevel[i].text = _levelSystem.GetLevel().ToString();
        }
    }
}
