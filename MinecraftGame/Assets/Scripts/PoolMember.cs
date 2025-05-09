using UnityEngine;

public class PoolMember : MonoBehaviour
{
    private double _durability;
    private int _materialID;
    private SpriteRenderer _spriteRenderer;
    private PoolManager _poolManager;

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
            Debug.Log(_durability);
            _durability -= _damage;
        }
        else
        {
            _poolManager.TeleportRow();
            gameObject.SetActive(false);
        }
    }
    public int GetMaterialID()
    {
        return _materialID;
    }
}
