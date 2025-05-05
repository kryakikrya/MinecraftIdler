using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mining : MonoBehaviour
{
    [SerializeField] private Transform _raycastPosition;
    private double _damage;
    private void Start()
    {
        _damage = 1;
    }
    private void FixedUpdate()
    {
        CheckRay(_damage);
    }
    private void CheckRay(double _damage)
    {
        RaycastHit2D hit = Physics2D.Raycast(_raycastPosition.position, Vector3.down, 10);
        if (hit)
        {
            hit.transform.GetComponent<PoolMember>().GetDamage(_damage); 
        }
        Debug.DrawRay(_raycastPosition.position, Vector3.down, Color.green);
    }
}
