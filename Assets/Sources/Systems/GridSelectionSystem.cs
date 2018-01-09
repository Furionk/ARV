using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using Entitas.Unity;
using Vuforia;
using Zenject;

public class GridSelectionSystem : ReactiveSystem<GameEntity> {

    private GameContext _gameContext;
    
    public GridSelectionSystem(GameContext context) : base(context) {
        _gameContext = context;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.Grid);
    }

    protected override bool Filter(GameEntity entity) {
        return true;
    }

    protected override void Execute(List<GameEntity> entities) {
        foreach (var gameEntity in entities) {
        }
    }

}
