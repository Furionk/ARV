using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine.Assertions;
using Zenject;

namespace ARV.System {

    public class GridPhysicsObjectCreationSystem : ReactiveSystem<GameEntity> {

        private GameContext _gameContext;
        [Inject]
        private DiContainer Container;

        public GridPhysicsObjectCreationSystem(GameContext context) : base(context) {
            _gameContext = context;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
            return context.CreateCollector(GameMatcher.VehicleToolPhysicsObject);
        }

        protected override bool Filter(GameEntity entity) {
            return entity.hasGrid;
        }

        protected override void Execute(List<GameEntity> entities) {
            foreach (var entity in entities) {
                string targetPrefabRes = string.Empty;
                if (entity.vehicleToolPhysicsObject.Type == VehicleTool.Wheel) {
                    targetPrefabRes = "Game/Wheel";
                } else if (entity.vehicleToolPhysicsObject.Type == VehicleTool.WoodBody) {
                    targetPrefabRes = "Game/Woodbody";
                }
                Assert.IsNotNull(targetPrefabRes);
                var go = Container.InstantiatePrefabResource(targetPrefabRes, entity.view.view.transform);
                go.transform.localPosition = Vector3.zero;
                entity.AddVehicleToolPhysicsView(go);
            }
        }



    }

}