using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using Zenject;

public class MenuButtonHandlingSystem : ReactiveSystem<InputEntity>, ICleanupSystem {

    private IGroup<InputEntity> _gOnMenuButtonDown;
    private GameContext _gameContext;
    private InputContext _inputContext;

    public MenuButtonHandlingSystem(InputContext inputContext, GameContext gameContext) : base(inputContext) {
        _inputContext = inputContext;
        _gameContext = gameContext;
        _gOnMenuButtonDown = inputContext.GetGroup(InputMatcher.OnMenuButtonDown);
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) {
        return context.CreateCollector(InputMatcher.OnMenuButtonDown);
    }

    protected override bool Filter(InputEntity entity) {
        return true;
    }

    protected override void Execute(List<InputEntity> entities) {
        foreach (var inputEntity in entities) {
            Debug.Log(inputEntity.onMenuButtonDown.buttonId);
            if (inputEntity.onMenuButtonDown.buttonId == "NEXT") {
                _gameContext.ReplaceGameMode(GameMode.Design);
            } else if (inputEntity.onMenuButtonDown.buttonId == "BACK") {
                _gameContext.ReplaceGameMode(GameMode.Menu);
            }
        }
    }

    public void Cleanup() {
        foreach (var entity in _gOnMenuButtonDown.GetEntities()) {
            entity.Destroy();
        }
    }

}
