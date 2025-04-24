using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class PoolMember : MonoBehaviour
{
    private double _durability;
    private int _materialID;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private PoolManager _poolManager;
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
    public void GetDamage(double _damage)
    {
        if (_durability - _damage > 0)
        {
            _durability -= _damage;
        }
        else
        {
            _poolManager.TeleportRow();
            gameObject.SetActive(false);
        }
    }
}
