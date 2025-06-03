using UnityEngine;

public class Upgrade : MonoBehaviour
{
    private double _damage;
    private double _modifier;
    [SerializeField] double _baseDamage;
    

    private void Start()
    {
        _damage += _baseDamage;
        _modifier = 1;
    }
    public void IncreaseDamage(double _upgrade)
    {
        _damage += _upgrade;
    }
    public double GetDamageValue()
    {
        return _damage * _modifier;
    }

    public double GetModifier()
    {
        return _modifier;
    }

    public void IncreaseModifier(double _upgrade)
    {
        _modifier += _upgrade;
    }
}
