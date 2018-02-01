using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using Vuforia;
using Zenject;
using Image = UnityEngine.UI.Image;

namespace ARV.System {

    public class ToolboxManagementSystem : ReactiveSystem<GameEntity> {

        private GameContext _gameContext;

        public ToolboxManagementSystem(GameContext context) : base(context) {
            _gameContext = context;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
            return context.CreateCollector(GameMatcher.IsSelected.AddedOrRemoved());
        }

        protected override bool Filter(GameEntity entity) {
            return entity.hasVehicleTool;
        }

        protected override void Execute(List<GameEntity> entities) {
            foreach (var gameEntity in entities) {
                if (gameEntity.hasIsSelected) {
                    gameEntity.view.view.GetComponent<Image>().color = Color.green;
                } else {
                    gameEntity.view.view.GetComponent<Image>().color = Color.white;
                }
            }
        }

    }

}