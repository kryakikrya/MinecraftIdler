using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
public class UIInventory : MonoBehaviour
{
    [SerializeField] private int _materialID;
    private Image _image;
    [SerializeField]  private TextMeshProUGUI _text;

    [Space]
    private Inventory _inventory;
    private List<Block> _blocksList;

    [Inject]
    private void Construct(Inventory inventory, List<Block> blocksList)
    {
        _inventory = inventory;
        _blocksList = blocksList;
    }

    private void Start()
    {
        _image = GetComponentInChildren<Image>();
        _image.sprite = _blocksList[_materialID].ItemSprite;
    }
    private void OnEnable()
    {
        _text.text = _inventory.GetMaterialValue(_materialID).ToString();
    }
}
