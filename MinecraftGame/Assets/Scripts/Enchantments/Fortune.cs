using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Fortune : MonoBehaviour
{
    [SerializeField] private int _buff;
    [SerializeField] private int _cost;
    private int _fortuneModifier = 1;

    [Space]
    private Expirience _levelSystem;

    [Inject]
    private void Construct(Expirience levelSystem)
    {
        _levelSystem = levelSystem;
    }

    public void IncreaseFortune()
    {
        if (_levelSystem.GetLevel() > _cost)
        {
            _levelSystem.LevelDown(_cost);
            _fortuneModifier += _buff;
        }
    }
}
