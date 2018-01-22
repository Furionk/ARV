using Entitas;
using UnityEngine;
using Zenject;

public class ContextInstaller : MonoInstaller<ContextInstaller> {


    public override void InstallBindings() {

        // Contexts
        Container.Bind<GameContext>()
            .FromInstance(Contexts.sharedInstance.game);
        Container.Bind<InputContext>()
            .FromInstance(Contexts.sharedInstance.input);

        // Systems        
        Container.Bind<InputSystem>().To<InputSystem>().AsSingle();
        Container.Bind<InputLogSystem>().To<InputLogSystem>().AsSingle();
        Container.Bind<GameInitSystem>().To<GameInitSystem>().AsSingle();
        Container.Bind<GameViewCreationSystem>().To<GameViewCreationSystem>().AsSingle();
        Container.Bind<SceneManagementSystem>().To<SceneManagementSystem>().AsSingle();
        Container.Bind<ButtonEventHandlingSystem>().To<ButtonEventHandlingSystem>().AsSingle();
        Container.Bind<GameModeSystem>().To<GameModeSystem>().AsSingle();
        Container.Bind<GridPositioningSystem>().To<GridPositioningSystem>().AsSingle();
        Container.Bind<GridSelectionSystem>().To<GridSelectionSystem>().AsSingle();
        Container.Bind<ToolboxViewCreationSystem>().To<ToolboxViewCreationSystem>().AsSingle();
        Container.Bind<ToolboxManagementSystem>().To<ToolboxManagementSystem>().AsSingle();

        // Features
        Container.Bind<Feature>().To<GameFlow>().AsSingle();
        Container.Bind<Feature>().To<Interaction>().AsSingle();

        // Entitas Core & Unity Utilities
        //Container.Bind<GameController>().FromComponentInNewPrefabResource("Bootstrap/GameController").AsSingle().NonLazy();
        //Container.Bind<SceneLoadUtility>().FromComponentInNewPrefabResource("Bootstrap/SceneLoader").AsSingle().NonLazy();
        Container.Bind<GameController>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
        Container.Bind<SceneLoadUtility>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
        Container.Bind<SoundController>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();

        // FB Scripts
        //Container.Bind<FBScripts>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
    }

}