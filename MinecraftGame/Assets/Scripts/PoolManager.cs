using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PoolManager : MonoBehaviour
{
    private List<CustomPool> _poolsList = new List<CustomPool>();
    private Transform _teleportPosition;
    private List<PoolMember> _blocksToDisable;
    private int _poolID;
    private int _totalRows;

    [Inject]
    private void Construct(List<CustomPool> poolsList, Transform teleportPosition, List<PoolMember> blocksToDisable)
    {
        _poolsList = poolsList;
        _teleportPosition = teleportPosition;
        _blocksToDisable = blocksToDisable;
    }

    private void Start()
    {
        _poolID = 0;
        for (int i = 0;  i < _blocksToDisable.Count; i++)
        {
            _blocksToDisable[i].gameObject.SetActive(false);
        }
    }

    public void TeleportRow()
    {
        _poolsList[_poolID].transform.position = _teleportPosition.position;
        _poolsList[_poolID].RandomBlocks();
        if (_poolID == _poolsList.Count - 1) _poolID = 0;
        else _poolID++;
    }
}
