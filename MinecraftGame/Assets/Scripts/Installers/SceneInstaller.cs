using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{

    [SerializeField] private List<Block> _blocksList;
    [Space] // eng
    [Header("INT SUMMARY == 100!")]
    [Header("Order of resources: iron, gold, diamond")]
    [Space] // ru
    [Header("ׁ׃ְּּ ְַֽ׳ֵָֹֽ == 100!")]
    [Header("ֿמנÿהמך נוסףנסמג: זוכוחמ, חמכמעמ, אכלאח")]

    [SerializeField] private List<int> _chansesList;
    [SerializeField] private int _oreChance;

    [SerializeField] private Generation _proceduralGeneration;

    [SerializeField] private List<CustomPool> _poolsList = new List<CustomPool>();
    [SerializeField] private Transform _teleportPosition;

    [SerializeField] private Inventory _inventory;

    [SerializeField] private Upgrade _damage;

    public override void InstallBindings()
    {
        Container.Bind<List<Block>>().FromInstance(_blocksList).AsSingle();
        Container.Bind<List<int>>().FromInstance(_chansesList).AsSingle();
        Container.Bind<int>().FromInstance(_oreChance).AsSingle();
        Container.Bind<Generation>().FromInstance(_proceduralGeneration).AsSingle();
        Container.Bind<List<CustomPool>>().FromInstance(_poolsList).AsSingle();
        Container.Bind<Transform>().FromInstance(_teleportPosition).AsSingle();
        Container.Bind<Inventory>().FromInstance(_inventory).AsSingle();
        Container.Bind<Upgrade>().FromInstance(_damage).AsSingle();
    }
}
