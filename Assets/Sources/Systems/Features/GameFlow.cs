using UnityEngine;
using System.Collections;
using Zenject;

public class GameFlow : Feature {

    public GameFlow(DiContainer container) : base("Game Flow") {
        Add(container.Resolve<GameViewCreationSystem>());
        Add(container.Resolve<SceneManagementSystem>());
        Add(container.Resolve<GameInitSystem>());
        Add(container.Resolve<GameModeSystem>());
        Add(container.Resolve<GridPositioningSystem>());
        Add(container.Resolve<GridSelectionSystem>());
    }

}
