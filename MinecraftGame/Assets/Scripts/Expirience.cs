using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using Zenject;

public class Expirience : MonoBehaviour
{
    private float _expirience;
    private int _level;
    private float _expirienceForNextLevel;

    private UIExpirience _uiExpirience;

    [Inject]
    private void Construct(UIExpirience uiExpirience)
    {
        _uiExpirience = uiExpirience;
    }

    private void Start()
    {
        _expirienceForNextLevel = 100;
    }
    public float GetExpirience()
    {
        return _expirience;
    }
    public int GetLevel()
    {
        return _level;
    }

    public float GetExpirienceForNextLevel()
    {
        return _expirienceForNextLevel;
    }
    public void IncreaseExpirience(float value)
    {
        _expirience += value;
        if (_expirience >= _expirienceForNextLevel)
        {
            _expirience -= _expirienceForNextLevel;
            LevelUp();
        }
        _uiExpirience.UpdateExpirience();
    }

    public void LevelUp()
    {
        _level += 1;
        _expirienceForNextLevel = (_level * 50 + 100) * 1.1f;
        _uiExpirience.UpdateLevel();
    }

    public void LevelDown(int value)
    {
        _level -= value;
        _expirienceForNextLevel = (_level * 50 + 100) * 1.1f;
        _uiExpirience.UpdateLevel();
    }
}
