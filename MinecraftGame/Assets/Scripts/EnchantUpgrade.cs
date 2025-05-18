using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(ChangeEnchantUI))]
public class EnchantUpgrade : MonoBehaviour
{
    private ChangeEnchantUI _enchantUI;
    private Sharpness _sharpness;
    private Fortune _fortune;

    [Inject]
    private void Construct(Sharpness sharpness, Fortune fortune)
    {
        _fortune = fortune;
        _sharpness = sharpness;
    }

    private void Start()
    {
        _enchantUI = GetComponent<ChangeEnchantUI>();
    }
    public void SharpnessEnchant()
    {
        _sharpness.EnchantWeapon();
        _enchantUI.ChangeCost();
    }

    public void FortuneEnchant()
    {
        _fortune.IncreaseFortune();
        _enchantUI.ChangeCost();
    }
}
