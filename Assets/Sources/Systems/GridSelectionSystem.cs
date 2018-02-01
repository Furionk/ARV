using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using Entitas.Unity;
using Vuforia;
using Zenject;

namespace ARV.System {

    public class GridSelectionSystem : ReactiveSystem<GameEntity> {

        private GameContext _gameContext;
        private Material _mSelected;
        private Material _mUnselected;
        private IGroup<GameEntity> _gSelectedVehicleTool;

        [InjectOptional(Id = "PlaceToolButton")]
        public Transform i_PlaceToolButton;

        public GridSelectionSystem(GameContext context) : base(context) {
            _gameContext = context;
            _mUnselected = Resources.Load<Material>("Game/Grid Unselected");
            _mSelected = Resources.Load<Material>("Game/Grid Selected");
            _gSelectedVehicleTool = _gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.VehicleTool, GameMatcher.IsSelected));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
            return context.CreateCollector(GameMatcher.IsSelected.AddedOrRemoved());
        }

        protected override bool Filter(GameEntity entity) {
            return entity.hasGrid && entity.hasView && !entity.hasVehicleToolPhysicsObject;
        }

        protected override void Execute(List<GameEntity> entities) {
            foreach (var gameEntity in entities) {
                if (gameEntity.hasIsSelected) {
                    if (_gSelectedVehicleTool.count > 0) {
                        gameEntity.view.view.GetComponent<MeshRenderer>().enabled = false;
                        i_PlaceToolButton.gameObject.SetActive(true);
                    } else {
                        i_PlaceToolButton.gameObject.SetActive(false);
                        gameEntity.view.view.GetComponent<MeshRenderer>().enabled = true;
                        gameEntity.view.view.GetComponent<MeshRenderer>().material = _mSelected;
                    }
                } else {
                    i_PlaceToolButton.gameObject.SetActive(false);
                    gameEntity.view.view.GetComponent<MeshRenderer>().enabled = true;
                    gameEntity.view.view.GetComponent<MeshRenderer>().material = _mUnselected;
                }
            }
        }

    }

}