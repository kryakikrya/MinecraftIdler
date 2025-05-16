using UnityEngine;

public class Upgrade : MonoBehaviour
{
    private double _damage;
    [SerializeField] double _baseDamage;

    private void Start()
    {
        _damage += _baseDamage;
    }
    public void IncreaseDamage(double _upgrade)
    {
        _damage += _upgrade;
    }
    public double GetDamageValue()
    {
        return _damage;
    }
}
