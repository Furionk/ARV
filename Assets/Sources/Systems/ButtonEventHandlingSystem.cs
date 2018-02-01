using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine.UI;
using Zenject;

namespace ARV.System {

    public class ButtonEventHandlingSystem : ReactiveSystem<InputEntity>, ICleanupSystem {

        private IGroup<InputEntity> _gOnMenuButtonDown;
        private IGroup<GameEntity> _gSelectedVehicleTool;
        private IGroup<GameEntity> _gSelectedGrid;
        private GameContext _gameContext;
        private InputContext _inputContext;

        [InjectOptional]
        public MenuController i_MenuController;

        [InjectOptional]
        public ARManager i_ARManager;

        [InjectOptional(Id = "PlaceToolButton")]
        public Transform i_PlaceToolButton;

        public ButtonEventHandlingSystem(InputContext inputContext, GameContext gameContext) : base(inputContext) {
            _inputContext = inputContext;
            _gameContext = gameContext;
            _gOnMenuButtonDown = inputContext.GetGroup(InputMatcher.OnMenuButtonDown);
            _gSelectedVehicleTool = _gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.VehicleTool, GameMatcher.IsSelected));
            _gSelectedGrid = _gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.Grid, GameMatcher.IsSelected));
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) {
            return context.CreateCollector(InputMatcher.OnMenuButtonDown);
        }

        protected override bool Filter(InputEntity entity) {
            return true;
        }

        protected override void Execute(List<InputEntity> entities) {
            foreach (var entity in entities) {
                var buttonId = entity.onMenuButtonDown.buttonId;
                //Debug.Log(buttonId);
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
                    i_ARManager.Reset();
                } else if (buttonId == "toolbox") {
                    i_MenuController.TogglePanel("pnl_toolbox");
                } else if (buttonId == "confrimplacetool") {
                    var selectedVehicleToolEntity = _gSelectedVehicleTool.GetEntities()[0];
                    var selectedGrid = _gSelectedGrid.GetEntities()[0];

                    VehicleTool type = selectedVehicleToolEntity.vehicleTool.Type;
                    selectedGrid.AddVehicleToolPhysicsObject(type);

                    GameObject.Destroy(selectedVehicleToolEntity.view.view);
                    selectedVehicleToolEntity.Destroy();

                    i_PlaceToolButton.gameObject.SetActive(false);
                }
            }
        }

        public void Cleanup() {
            foreach (var entity in _gOnMenuButtonDown.GetEntities()) {
                entity.Destroy();
            }
        }

    }

}

