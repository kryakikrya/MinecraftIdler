using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CustomPool : MonoBehaviour
{
    public List<PoolMember> _pool = new List<PoolMember>();
    private Generation _proceduralGeneration;

    [Inject]
    private void Construct(Generation proceduralGeneration)
    {
        _proceduralGeneration = proceduralGeneration;
    }


    private void Start()
    {
        PoolMember[] _pmArray = GetComponentsInChildren<PoolMember>(true);
        _pool = new List<PoolMember>(_pmArray);
        for (int i = 0; i < _pool.Count; i++) // go through the list of pool elements
        {
            _proceduralGeneration.Randomizer(_pool[i]);
        }
    }
    public void RandomBlocks()
    {
        for (int i = 0; i < _pool.Count; i++) // go through the list of pool elements
        {
            _pool[i].gameObject.SetActive(true);
            _proceduralGeneration.Randomizer(_pool[i]);
        }
    }
}
