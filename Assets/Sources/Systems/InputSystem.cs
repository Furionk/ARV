using UnityEngine;
using System.Collections;
using Entitas;
using Zenject;

namespace ARV.System {

    public class InputSystem : IExecuteSystem {

        private InputContext _inputContext;

        public InputSystem(InputContext inputContext) {
            _inputContext = inputContext;
        }

        public void Execute() {

            if (Input.anyKey) {
                _inputContext.CreateEntity().AddOnMouseDown(Input.mousePosition.x, Input.mousePosition.y);
            }
        }

    }

}