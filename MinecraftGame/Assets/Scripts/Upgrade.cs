using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    private double _damage;

    private void Start()
    {
        _damage = 10;
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
