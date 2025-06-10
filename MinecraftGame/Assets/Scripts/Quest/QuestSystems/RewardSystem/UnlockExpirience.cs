using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UnlockExpirience : RewardSystem
{
    private Expirience _expirience;
    [SerializeField] List<GameObject> _panels;

    [Inject]
    private void Construct(Expirience expirience)
    {
        _expirience = expirience;
    }
    public override void GetReward()
    {
        for (int i = 0; i < _panels.Count; i++)
        {
            _panels[i].SetActive(true);
        }
        _expirience.SetActive();
    }
}