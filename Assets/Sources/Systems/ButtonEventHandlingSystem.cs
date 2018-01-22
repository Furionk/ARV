using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using Zenject;

public class ButtonEventHandlingSystem : ReactiveSystem<InputEntity>, ICleanupSystem {

    private IGroup<InputEntity> _gOnMenuButtonDown;
    private GameContext _gameContext;
    private InputContext _inputContext;


    public ButtonEventHandlingSystem(InputContext inputContext, GameContext gameContext) : base(inputContext) {
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
            var buttonId = inputEntity.onMenuButtonDown.buttonId;
            Debug.Log(buttonId);
            if (buttonId == "NEXT") {
                _gameContext.ReplaceGameMode(GameMode.Design);
            } else if (buttonId == "BACK") {
                _gameContext.ReplaceGameMode(GameMode.Menu);
                _gameContext.ReplaceGameMode(GameMode.Menu);
            } else if (buttonId.Contains("level")) {
                if (buttonId == "level1") {
                    _gameContext.CreateEntity().AddGameMode(GameMode.Design);
                }
            } else if (buttonId == "simulate") {
                _gameContext.CreateEntity().AddGameMode(GameMode.Simulation);
            } else if (buttonId == "reset") {
                // TODO : wait for optimize
                GameObject.FindObjectOfType<ARManager>().Reset();
            } else if (buttonId == "toolbox") {
                GameObject.FindObjectOfType<MenuController>().TogglePanel("pnl_toolbox");
            }
        }
    }

    public void Cleanup() {
        foreach (var entity in _gOnMenuButtonDown.GetEntities()) {
            entity.Destroy();
        }
    }

}
