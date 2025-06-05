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
    private Coroutine _cooldown;

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
        _image = GetComponentInChildren<Image>(true);
        _image.sprite = _blocksList[_materialID].ItemSprite;
        _cooldown = StartCoroutine(Cooldown());
    }
    private void OnEnable()
    {
        _text.text = _inventory.GetMaterialValue(_materialID).ToString();
        StartCoroutine(Cooldown());
    }
    private void UpdateText()
    {
        _text.text = _inventory.GetMaterialValue(_materialID).ToString();
    }

    IEnumerator Cooldown()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            _text.text = _inventory.GetMaterialValue(_materialID).ToString();
        }
    }

    private void OnDisable()
    {
        StopCoroutine(_cooldown);
    }
}
