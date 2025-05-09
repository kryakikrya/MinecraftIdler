using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Mining : MonoBehaviour
{
    [SerializeField] private Transform _raycastPosition;
    [SerializeField] private Upgrade _damage;
    private Inventory _inventory;

    private void FixedUpdate()
    {
        CheckRay(_damage.GetDamageValue());
    }
    private void CheckRay(double _damage)
    {
        RaycastHit2D hit = Physics2D.Raycast(_raycastPosition.position, Vector3.down, 1);
        if (hit)
        {
            PoolMember _poolMember = hit.transform.GetComponent<PoolMember>();
            _poolMember.GetDamage(_damage);
        }
    }
}
