using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{

    [SerializeField] private List<Block> _blocksList;
    [Space] // eng
    [Header("INT SUMMARY == 100!")]
    [Header("Order of resources: iron, gold, diamond")]

    [SerializeField] private List<int> _chansesList;
    [SerializeField] private int _oreChance;

    [SerializeField] private Generation _proceduralGeneration;

    [SerializeField] private List<CustomPool> _poolsList = new List<CustomPool>();
    [SerializeField] private Transform _teleportPosition;

    [SerializeField] private Inventory _inventory;

    [SerializeField] private Upgrade _damage;

    [SerializeField] private List<Items> _itemsList;

    [SerializeField] List<PoolMember> _blocksToDisable;

    [SerializeField] private Expirience _expirience;

    [SerializeField] private UIExpirience _uiExpirience;

    [SerializeField] private AddNewBlocks _addNewBlocks;

    [SerializeField] private Sharpness _sharpness;

    [SerializeField] private Fortune _fortune;

    [SerializeField] private List<Quest> _quests;

    [SerializeField] private QuestsUI _questsUI;

    public override void InstallBindings()
    {
        Container.Bind<List<Block>>().FromInstance(_blocksList).AsSingle().NonLazy();
        Container.Bind<List<int>>().FromInstance(_chansesList).AsSingle().NonLazy();
        Container.Bind<int>().FromInstance(_oreChance).AsSingle().NonLazy();
        Container.Bind<Generation>().FromInstance(_proceduralGeneration).AsSingle().NonLazy();
        Container.Bind<List<CustomPool>>().FromInstance(_poolsList).AsSingle().NonLazy();
        Container.Bind<Transform>().FromInstance(_teleportPosition).AsSingle().NonLazy();
        Container.Bind<Inventory>().FromInstance(_inventory).AsSingle().NonLazy();
        Container.Bind<Upgrade>().FromInstance(_damage).AsSingle().NonLazy();
        Container.Bind<List<Items>>().FromInstance(_itemsList).AsSingle().NonLazy();
        Container.Bind<List<PoolMember>>().FromInstance(_blocksToDisable).AsSingle().NonLazy();
        Container.Bind<Expirience>().FromInstance(_expirience).AsSingle().NonLazy();
        Container.Bind<UIExpirience>().FromInstance(_uiExpirience).AsSingle().NonLazy();
        Container.Bind<AddNewBlocks>().FromInstance(_addNewBlocks).AsSingle().NonLazy();
        Container.Bind<Sharpness>().FromInstance(_sharpness).AsSingle().NonLazy();
        Container.Bind<Fortune>().FromInstance(_fortune).AsSingle().NonLazy();
        Container.Bind<List<Quest>>().FromInstance(_quests).AsSingle().NonLazy();
        Container.Bind<QuestsUI>().FromInstance(_questsUI).AsSingle().NonLazy();
    }
}
