using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Mining : MonoBehaviour
{
    [SerializeField] private Transform _raycastPosition;
    private Upgrade _damage;
    [SerializeField] float _miningCD;

    [Inject]
    private void Construct(Upgrade damage)
    {
        _damage = damage;
    }
    private void Start()
    {
        StartCoroutine(MiningCD(_miningCD));
    }
    private void CheckRay(double _damage)
    {
        RaycastHit2D hit = Physics2D.Raycast(_raycastPosition.position, Vector3.down, 1);
        if (hit)
        {
            PoolMember _poolMember = hit.transform.GetComponent<PoolMember>();
            _poolMember.GetDamage(_damage, false);
        }
    }
    private IEnumerator MiningCD(float _miningCD)
    {
        while (true)
        {
            yield return new WaitForSeconds(_miningCD);
            CheckRay(_damage.GetDamageValue());
        }
    }
}
