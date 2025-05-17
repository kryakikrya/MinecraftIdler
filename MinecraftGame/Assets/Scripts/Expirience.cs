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

    [SerializeField] float _baseExpirience;
    [SerializeField] float _levelModifier;

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
        UpdateExpirienceForNextLevel();
        _uiExpirience.UpdateLevel();
    }

    public void LevelDown(int value)
    {
        _level -= value;
        UpdateExpirienceForNextLevel();
        _uiExpirience.UpdateLevel();
    }

    private void UpdateExpirienceForNextLevel()
    {
        float _difficulty = _baseExpirience / 2;
        for (int i = 1; i < _level; i++)
        {
            _difficulty *= _levelModifier;
        }
        _expirienceForNextLevel = _baseExpirience + _difficulty;
    }
}
