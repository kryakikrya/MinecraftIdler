using UnityEngine;
using Zenject;
using System.Collections.Generic;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class PoolMember : MonoBehaviour
{
    private double _durability;
    private int _materialID;
    private float _expirience;
    private SpriteRenderer _spriteRenderer;
    private PoolManager _poolManager;
    private Inventory _inventory;
    private Expirience _levelSystem;
    private SoundManager _soundManager;


    [Inject]
    private void Construct(Inventory inventory, Expirience levelSystem, SoundManager soundManager)
    {
        _inventory = inventory;
        _levelSystem = levelSystem;
        _soundManager = soundManager;
    }

    private void Awake()
    {
        _poolManager = gameObject.GetComponentInParent<PoolManager>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
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
    public void GetDamage(double _damage, bool _isLMB)
    {
        if (_durability - _damage > 0)
        {
            _durability -= _damage;
        }
        else
        {
            if (_isLMB == false)
            {
                _poolManager.TeleportRow();
            }
            _inventory.PutInInventory(_materialID, 1);
            _levelSystem.IncreaseExpirience(_expirience);
            _soundManager.PlayClip(0);
            gameObject.SetActive(false);
        }
    }
    public int GetMaterialID()
    {
        return _materialID;
    }
}