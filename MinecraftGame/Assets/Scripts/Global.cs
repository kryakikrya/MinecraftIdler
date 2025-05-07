using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    [SerializeField] private List<Block> _blocksList;

    [Space] // eng
    [Header("INT SUMMARY == 100!")]
    [Header("Order of resources: iron, gold, diamond")]
    [Space] // ru
    [Header("����� �������� == 100!")]
    [Header("������� ��������: ������, ������, �����")]

    [SerializeField] private List<int> _chansesList;
    public List<Block> GetBlockList()
    {
        return _blocksList;
    }
    public List<int> GetChancesList()
    {
        return _chansesList;
    }
}
