using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mining : MonoBehaviour
{
    [SerializeField] private Transform _raycastPosition;
    private double _damage;
    private void Update()
    {
        CheckRay();
    }
    private void CheckRay()
    {
        Ray ray = new Ray(_raycastPosition.position, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            hit.transform.GetComponent<PoolMember>().GetDamage(1); 
        }
    }
}
