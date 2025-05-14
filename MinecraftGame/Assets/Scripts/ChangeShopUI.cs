using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(ShopUpgradingWeapon))]
public class ChangeShopUI : MonoBehaviour
{
    private ShopUpgradingWeapon _panel;
    [SerializeField] private List<Image> _imagesList;
    [SerializeField] private List<TextMeshProUGUI> _textList;
    [SerializeField] private Image _resultImage;
    [SerializeField] private int _resultItemID;
    private List<Block> _blocksList;
    private List<Items> _itemsList;
    [SerializeField] List<GameObject> _blocksToDisable;

    [Inject]
    private void Construct(List<Block> blocksList, List<Items> itemsList)
    {
        _blocksList = blocksList;
        _itemsList = itemsList;
    }
    void Start()
    {
        _panel = GetComponent<ShopUpgradingWeapon>();
        ChangeImage(_panel.GetMaterialsIDList());
        ChangeCost(_panel.GetCostsList());
    }
    private void ChangeImage(List<int> _materialIDList)
    {
        for (int i = 0; i < _materialIDList.Count; i++)
        {
            _imagesList[i].gameObject.SetActive(true);
            _imagesList[i].sprite = _blocksList[_materialIDList[i]].ItemSprite;
        }
        _resultImage.sprite = _itemsList[_resultItemID].ItemSprite;
    }
    private void ChangeCost(List<int> _costsList)
    {
        for (int i = 0; i < _costsList.Count; i++)
        {
            _textList[i].gameObject.SetActive(true);
            _textList[i].text = _costsList[i].ToString();
        }
    }

}
