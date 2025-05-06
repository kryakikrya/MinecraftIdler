using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mining : MonoBehaviour
{
    [SerializeField] private Transform _raycastPosition;
    [SerializeField] private Upgrade _damage;
    [SerializeField] private Inventory _inventory;
    private void FixedUpdate()
    {
        CheckRay(_damage.GetDamageValue());
    }
    private void CheckRay(double _damage)
    {
        RaycastHit2D hit = Physics2D.Raycast(_raycastPosition.position, Vector3.down, 10);
        if (hit)
        {
            PoolMember _poolMember = hit.transform.GetComponent<PoolMember>();
            _poolMember.GetDamage(_damage);
            _inventory.PutInInventory(_poolMember.GetMaterialID(), 1);
        }
        Debug.DrawRay(_raycastPosition.position, Vector3.down, Color.green);
    }
}
