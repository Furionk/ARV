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
    private Material _mSelected;
    private Material _mUnselected;

    public GridSelectionSystem(GameContext context) : base(context) {
        _gameContext = context;
        _mUnselected = Resources.Load<Material>("Game/Grid Unselected");
        _mSelected = Resources.Load<Material>("Game/Grid Selected");
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.IsSelected.AddedOrRemoved());
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasGrid && entity.hasView;
    }

    protected override void Execute(List<GameEntity> entities) {
        foreach (var gameEntity in entities) {
            if (gameEntity.hasIsSelected) {
                gameEntity.view.view.GetComponent<MeshRenderer>().material = _mSelected;
            } else {
                gameEntity.view.view.GetComponent<MeshRenderer>().material = _mUnselected;
            }
        }
    }

}
