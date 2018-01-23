using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using Vuforia;
using Zenject;

namespace ARV.System {

    public class GameModeSystem : ReactiveSystem<GameEntity> {

        private GameContext _gameContext;

        [Inject]
        private DiContainer Container;

        public GameModeSystem(GameContext context) : base(context) {
            _gameContext = context;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
            return context.CreateCollector(GameMatcher.GameMode);
        }

        protected override bool Filter(GameEntity entity) {
            return true;
        }

        protected override void Execute(List<GameEntity> entities) {
            var e = entities.FirstOrDefault();
            Debug.Log("[R] Game Mode Changed " + e.gameMode.gameMode.ToString());
            if (e.gameMode.gameMode == GameMode.Design) {
                _gameContext.ReplaceOnSceneLoad("Design");
            } else if (e.gameMode.gameMode == GameMode.Menu) {
                _gameContext.ReplaceOnSceneLoad("Menu");
            } else if (e.gameMode.gameMode == GameMode.Simulation) {
                //_gameContext.ReplaceOnSceneLoad("Simulation");
            }
        }

    }

}