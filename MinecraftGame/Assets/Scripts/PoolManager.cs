using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] private List<CustomPool> _poolsList = new List<CustomPool>();
    [SerializeField] private Transform _teleportPosition;

    private int _poolID = 0;
    public void TeleportRow()
    {
        _poolsList[_poolID].transform.position = _teleportPosition.position;
        if (_poolID == _poolsList.Count - 1) _poolID = 0;
        else _poolID++;
        _poolsList[_poolID].RandomBlocks();
    }
}
