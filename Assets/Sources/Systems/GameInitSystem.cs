﻿using UnityEngine;
using System.Collections;
using Entitas;
using Zenject;

namespace ARV.System {

    public class GameInitSystem : IInitializeSystem {

        [Inject]
        public GameContext game;


        public void Initialize() {

        }

    }

}