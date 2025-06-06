using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(PoolMember))]
public class LMBShooting : MonoBehaviour
{
    private Upgrade _damage;
    private CanLMB _canShoot;
    private PoolMember _poolMember;
    private ParticleEffect _particleEffect;

    [Inject]
    private void Construct(Upgrade damage, CanLMB canLMB, ParticleEffect particleEffect)
    {
        _damage = damage;
        _canShoot = canLMB;
        _particleEffect = particleEffect;
    }

    private void OnEnable()
    {
        _canShoot.SetCanShoot(true);
        if (_poolMember == null)
            _poolMember = GetComponent<PoolMember>();
    }
    private void OnMouseDown()
    {
        if (_canShoot.GetCanShoot())
        {
            _poolMember.GetDamage(_damage.GetDamageValue() * 3, true);
            _canShoot.SetCanShoot(false);
            _particleEffect.ClickEffect(_poolMember.transform.position);
        }
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        _poolMember = GetComponent<PoolMember>();
    }
#endif
}
