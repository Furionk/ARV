using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using Vuforia;
using Zenject;

public class GridCreationSystem : ReactiveSystem<GameEntity> {

    private GameContext _gameContext;
    private GameObject _pGrid;
    private GameObject _center;

    public GridCreationSystem(GameContext context) : base(context) {
        _gameContext = context;
        _pGrid = Resources.Load<GameObject>("Game/Grid");
        _center = GameObject.FindWithTag("Grid Center");
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.Grid);
    }

    protected override bool Filter(GameEntity entity) {
        return true;
    }

    protected override void Execute(List<GameEntity> entities) {
        foreach (var gameEntity in entities) {
            GameObject.Instantiate(_pGrid, gameEntity.grid.position * 0.1f, Quaternion.identity, _center.transform);
        }
    }

}
