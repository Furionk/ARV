using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine.Assertions;
using Zenject;

public class ToolboxViewCreationSystem : ReactiveSystem<GameEntity> {

    private GameContext _gameContext;

    private Lazy<MenuController> mMenuController;

    public ToolboxViewCreationSystem(GameContext context, Lazy<MenuController> menuControl) : base(context) {
        _gameContext = context;
        mMenuController = menuControl;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.VehiclePart);
    }

    protected override bool Filter(GameEntity entity) {
        return true;
    }

    protected override void Execute(List<GameEntity> entities) {
        foreach (var entity in entities) {
            string resourceLocation = string.Empty;
            if (entity.vehiclePart.Name == "Wheel") {
                resourceLocation = "Game/WheelIcon";
            } else if (entity.vehiclePart.Name == "WoodBody") {
                resourceLocation = "Game/WoodbodyIcon";
            }

            Assert.IsNotNull(mMenuController.Value);

            ////var go = GameObject.Instantiate(Resources.Load(resourceLocation), toolbox.transform) as GameObject;
            ////go.Link(entity, _gameContext);
            ////entity.AddView(go);
        }
    }



}
