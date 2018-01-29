using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using Zenject;

namespace ARV.System {

    public class GameViewCreationSystem : ReactiveSystem<GameEntity> {

        private GameContext _gameContext;

        public GameViewCreationSystem(GameContext context) : base(context) {
            _gameContext = context;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
            return context.CreateCollector(GameMatcher.Resources);
        }

        protected override bool Filter(GameEntity entity) {
            return !entity.hasVehicleTool;
        }

        protected override void Execute(List<GameEntity> entities) {
            foreach (var entity in entities) {
                var go = GameObject.Instantiate(Resources.Load(entity.resources.prefabPath)) as GameObject;
                go.Link(entity, _gameContext);
                entity.AddView(go);
            }
        }



    }

}