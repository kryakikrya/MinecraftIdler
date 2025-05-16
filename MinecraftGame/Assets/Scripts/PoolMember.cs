using UnityEngine;
using Zenject;
using System.Collections.Generic;

[RequireComponent(typeof(SpriteRenderer))]
public class PoolMember : MonoBehaviour
{
    private double _durability;
    private int _materialID;
    private float _expirience;
    private SpriteRenderer _spriteRenderer;
    private PoolManager _poolManager;

    private Inventory _inventory;

    private List<GameObject> _blocksToDisableAtStart;

    private Expirience _levelSystem;


    [Inject]
    private void Construct(Inventory inventory, List<GameObject> blocksToDisable, Expirience levelSystem)
    {
        _inventory = inventory;
        _blocksToDisableAtStart = blocksToDisable;
        _levelSystem = levelSystem;
    }

    private void Awake()
    {
        _poolManager = gameObject.GetComponentInParent<PoolManager>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        for (int i = 0; i < _blocksToDisableAtStart.Count; i++)
        {
            _blocksToDisableAtStart[i].SetActive(false);
        }
    }

    public void ChangeDurability(double _newDurability)
    {
        _durability = _newDurability;
    }
    public void ChangeSprite(Sprite _newSprite)
    {
        _spriteRenderer.sprite = _newSprite;
    }
    public void ChangeID(int _newID)
    {
        _materialID = _newID;
    }

    public void ChangeExpirience(float _newExpirience)
    {
        _expirience = _newExpirience;
    }
    public void GetDamage(double _damage)
    {
        if (_durability - _damage > 0)
        {
            _durability -= _damage;
        }
        else
        {
            _poolManager.TeleportRow();
            _inventory.PutInInventory(_materialID, 1);
            _levelSystem.IncreaseExpirience(_expirience);
            gameObject.SetActive(false);
        }
    }
    public int GetMaterialID()
    {
        return _materialID;
    }
}
