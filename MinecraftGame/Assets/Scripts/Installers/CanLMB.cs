using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanLMB : MonoBehaviour
{
    [SerializeField] private bool _canLMB = true;
    float _miningCD = 2f;

    private IEnumerator MiningCD(float _miningCD)
    {
        yield return new WaitForSeconds(_miningCD);
        _canLMB = true;
    }
    public bool GetCanShoot()
    {
        return _canLMB;
    }
    public void SetCanShoot(bool value)
    {
        if (value == false)
        {
            _canLMB = false;
            StartCoroutine(MiningCD(_miningCD));
        }
        else
        {
            _canLMB = true;
        }
    }
}
