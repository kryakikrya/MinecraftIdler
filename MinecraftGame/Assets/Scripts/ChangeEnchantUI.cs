using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ChangeEnchantUI : MonoBehaviour
{
    [Header("0 - Sharpness, 1 - Fortune")]
    [SerializeField] private int _type;
    [SerializeField] private TextMeshProUGUI _text;
    private Sharpness _sharpness;
    private Fortune _fortune;


    [Inject]
    private void Construct(Sharpness sharpness, Fortune fortune)
    {
        _fortune = fortune;
        _sharpness = sharpness;
    }
    void Start()
    {
        ChangeCost();
    }
    public void ChangeCost()
    {
        if (_type == 0)
        {
            _text.text = _sharpness.GetCost().ToString();
        }
        else if (_type == 1)
        {
            _text.text = _fortune.GetCost().ToString();
        }
    }

}