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

    [SerializeReference] private List<MainQuest> _mainQuestList;

    [SerializeReference] private List<SideQuest> _sideQuestList;

    [SerializeField] private List<BlockToAdd> _blocksToAdd;

    [SerializeField] private List<UnlockNewMenu> _unlockableMenuList;

    [SerializeField] private SwitchCurrentReward _switchCurrentReward;

    [SerializeField] private AddExpirience _addExpirience;

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
        Container.Bind<List<Items>>().FromInstance(_itemsList).AsSingle();
        Container.Bind<List<PoolMember>>().FromInstance(_blocksToDisable).AsSingle();
        Container.Bind<Expirience>().FromInstance(_expirience).AsSingle();
        Container.Bind<UIExpirience>().FromInstance(_uiExpirience).AsSingle();
        Container.Bind<AddNewBlocks>().FromInstance(_addNewBlocks).AsSingle();
        Container.Bind<Sharpness>().FromInstance(_sharpness).AsSingle();
        Container.Bind<Fortune>().FromInstance(_fortune).AsSingle();
        Container.Bind<List<MainQuest>>().FromInstance(_mainQuestList).AsSingle();
        Container.Bind<List<SideQuest>>().FromInstance(_sideQuestList).AsSingle();
        Container.Bind<List<BlockToAdd>>().FromInstance(_blocksToAdd).AsSingle();
        Container.Bind<List<UnlockNewMenu>>().FromInstance(_unlockableMenuList).AsSingle();
        Container.Bind<SwitchCurrentReward>().FromInstance(_switchCurrentReward).AsSingle();
        Container.Bind<AddExpirience>().FromInstance(_addExpirience).AsSingle();
    }
}
