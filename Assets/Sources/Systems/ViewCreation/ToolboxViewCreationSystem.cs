using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine.Assertions;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace ARV.System {

    public class ToolboxViewCreationSystem : ReactiveSystem<GameEntity> {

        private GameContext _gameContext;

        private int _selectedTool = -1;

        [InjectOptional(Id = "ToolboxContent")]
        private Transform toolboxTransfrom;

        [Inject]
        private DiContainer Container;
        private IGroup<GameEntity> _gSelectedVehicleTool;

        public ToolboxViewCreationSystem(GameContext context) : base(context) {
            _gameContext = context;
            _gSelectedVehicleTool = _gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.VehicleTool, GameMatcher.IsSelected));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
            return context.CreateCollector(GameMatcher.VehicleTool);
        }

        protected override bool Filter(GameEntity entity) {
            return true;
        }

        protected override void Execute(List<GameEntity> entities) {
            foreach (var entity in entities) {
                string targetIcon = string.Empty;
                Assert.IsNotNull(toolboxTransfrom);
                var go = Container.InstantiatePrefabResource("Game/ToolIcon", toolboxTransfrom);
                if (entity.vehicleTool.Type == VehicleTool.Wheel) {
                    targetIcon = "Icon/wheel";
                } else if (entity.vehicleTool.Type == VehicleTool.WoodBody) {
                    targetIcon = "Icon/woodenbox";
                }
                Assert.IsNotNull(targetIcon);
                go.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(targetIcon);
                go.GetComponent<Button>().onClick.AddListener(() => OnToolboxButtonClick(entity));
                go.Link(entity, _gameContext);
                entity.AddView(go);
            }
        }

        public void OnToolboxButtonClick(GameEntity selectedGameEntity) {
            foreach (var gameEntity in _gSelectedVehicleTool.GetEntities()) {
                gameEntity.RemoveIsSelected();
            }
            selectedGameEntity.AddIsSelected(0);
        }

    }

}