using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PoolManager : MonoBehaviour
{
    private List<CustomPool> _poolsList = new List<CustomPool>();
    private Transform _teleportPosition;

    [Inject]
    private void Construct(List<CustomPool> poolsList, Transform teleportPosition)
    {
        _poolsList = poolsList;
        _teleportPosition = teleportPosition;
    }

    private int _poolID = 0;
    public void TeleportRow()
    {
        _poolsList[_poolID].transform.position = _teleportPosition.position;
        if (_poolID == _poolsList.Count - 1) _poolID = 0;
        else _poolID++;
        _poolsList[_poolID].RandomBlocks();
    }
}
