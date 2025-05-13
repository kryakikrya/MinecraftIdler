using UnityEngine;

public class Upgrade : MonoBehaviour
{
    private double _damage;

    private void Start()
    {
        _damage = 30;
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
