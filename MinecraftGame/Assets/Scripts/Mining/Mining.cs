using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Mining : MonoBehaviour
{
    [SerializeField] private Transform _raycastPosition;
    private Upgrade _damage;
    [SerializeField] float _miningCD;
    private ParticleEffect _particleEffect;

    [Inject]
    private void Construct(Upgrade damage, ParticleEffect particleEffect)
    {
        _damage = damage;
        _particleEffect = particleEffect;
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
            _particleEffect.ClickEffect(_poolMember.gameObject.transform.position + Vector3.up);
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
