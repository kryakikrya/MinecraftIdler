using UnityEngine;
using Zenject;

public class PoolMember : MonoBehaviour
{
    private double _durability;
    private int _materialID;
    private SpriteRenderer _spriteRenderer;
    private PoolManager _poolManager;

    private Inventory _inventory;

    [Inject]
    private void Construct(Inventory inventory)
    {
        _inventory = inventory;
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
            gameObject.SetActive(false);
        }
    }
    public int GetMaterialID()
    {
        return _materialID;
    }
}
