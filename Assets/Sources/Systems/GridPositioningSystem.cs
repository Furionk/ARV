using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using Entitas.Unity;
using Vuforia;
using Zenject;

public class GridPositioningSystem : ReactiveSystem<GameEntity> {

    private GameContext _gameContext;

    [Inject(Id = "Offset")]
    private float offset;

    public GridPositioningSystem(GameContext context) : base(context) {
        _gameContext = context;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.OnGridCreated);
        //return context.CreateCollector(GameMatcher.View.Added());
    }

    protected override bool Filter(GameEntity entity) {
        return true;
        //return entity.hasGrid;
    }

    protected override void Execute(List<GameEntity> entities) {
        GameObject _center = GameObject.FindGameObjectWithTag("Grid Center");

        foreach (var gameEntity in entities) {
            gameEntity.Destroy();
        }

        float? maxX = null, maxZ = null;

        foreach (var gameEntity in _gameContext.GetEntities(GameMatcher.AllOf(GameMatcher.Grid))) {
            gameEntity.view.view.transform.SetParent(_center.transform);
            gameEntity.view.view.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            gameEntity.view.view.transform.position = gameEntity.grid.position * offset;

            if (!maxX.HasValue || gameEntity.view.view.transform.position.x > maxX)
                maxX = gameEntity.view.view.transform.position.x;
            if (!maxZ.HasValue || gameEntity.view.view.transform.position.z > maxZ)
                maxZ = gameEntity.view.view.transform.position.z;

        }
        // shift position and reparenting
        //foreach (var gameEntity in _gameContext.GetEntities(GameMatcher.AllOf(GameMatcher.Grid))) {
        //    gameEntity.view.view.transform.Translate(-1*maxX.Value/2, 0, -1*maxZ.Value/2);
        //}
        //_center.transform.Translate(-1 * maxX.Value / 2, 0, -1 * maxZ.Value / 2, Space.World);
        //_center.transform.position = new Vector3(_center.transform.position.x, 0.2f, _center.transform.position.z);
    }

}
