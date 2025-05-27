using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(PoolMember))]
public class LMBShooting : MonoBehaviour
{
    private Upgrade _damage;
    float _miningCD = 0.5f;
    private bool _canShoot = true;
    private PoolMember _poolMember;

    [Inject]
    private void Construct(Upgrade damage)
    {
        _damage = damage;
    }

    private void OnEnable()
    {
        _canShoot = true;
        if (_poolMember == null)
            _poolMember = GetComponent<PoolMember>();
    }
    private void OnMouseDown()
    {
        if (_canShoot)
        {
            _poolMember.GetDamage(_damage.GetDamageValue() * 2, true);
            _canShoot = false;
            if (gameObject.activeSelf == true)
            {
                StartCoroutine(MiningCD(_miningCD));
            }
        }
    }

    private IEnumerator MiningCD(float _miningCD)
    {
        yield return new WaitForSeconds(_miningCD);
        _canShoot = true;
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        _poolMember = GetComponent<PoolMember>();
    }
#endif
}
