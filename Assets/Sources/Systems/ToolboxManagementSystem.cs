using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using Vuforia;
using Zenject;

public class ToolboxManagementSystem : ReactiveSystem<GameEntity> {

    private GameContext _gameContext;

    public ToolboxManagementSystem(GameContext context) : base(context) {
        _gameContext = context;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.VehiclePart);
    }

    protected override bool Filter(GameEntity entity) {
        return true;
    }

    protected override void Execute(List<GameEntity> entities) {
        foreach (var gameEntity in entities) {
            
        }
    }

}
