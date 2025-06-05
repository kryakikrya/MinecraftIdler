using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using Zenject;

public class Expirience : MonoBehaviour
{
    private bool _isActive = false;

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

    public void SetActive()
    {
        _isActive = true;
        _uiExpirience.TurnOn();
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
        if (_isActive)
        {
            _expirience += value;
            if (_expirience >= _expirienceForNextLevel)
            {
                _expirience -= _expirienceForNextLevel;
                LevelUp();
            }
            _uiExpirience.UpdateExpirience();
        }
    }

    public void LevelUp()
    {
        _level += 1;
        _expirience = 0;
        _uiExpirience.UpdateExpirience();
        UpdateExpirienceForNextLevel();
        _uiExpirience.UpdateLevel();
        Debug.Log("Level " + GetLevel().ToString() + " Exp for the new level " + GetExpirienceForNextLevel().ToString());
    }

    public void LevelDown(int value)
    {
        if (_level - value >= 0)
        {
            _level -= value;
            _expirience = 0;
            _uiExpirience.UpdateExpirience();
            UpdateExpirienceForNextLevel();
            _uiExpirience.UpdateLevel();
            Debug.Log("Level " + GetLevel().ToString() + " Exp for the new level " + GetExpirienceForNextLevel().ToString());
        }
    }

    private void UpdateExpirienceForNextLevel()
    {
        float _difficulty = _baseExpirience;
        for (int i = 1; i < _level; i++)
        {
            _difficulty *= _levelModifier;
        }
        _expirienceForNextLevel = _baseExpirience + _difficulty;
    }
}
