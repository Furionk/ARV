using Entitas;
using UnityEngine;
using Zenject;
using ARV.System;

public class ContextInstaller : MonoInstaller<ContextInstaller> {


    public override void InstallBindings() {

        // Contexts
        Container.Bind<GameContext>()
            .FromInstance(Contexts.sharedInstance.game);
        Container.Bind<InputContext>()
            .FromInstance(Contexts.sharedInstance.input);

        // Systems     
        Container.Bind<ISystem>().WithId(FeatureType.All).To(o=>o.AllNonAbstractClasses().InNamespace("ARV.System")).AsSingle();
        //Container.Bind<ISystem>().WithId("All").To(x => x.AllTypes().DerivingFrom<IExecuteSystem>());

        Container.Bind<ISystem>().WithId(FeatureType.Interaction).To<InputSystem>().AsSingle();
        Container.Bind<ISystem>().WithId(FeatureType.Interaction).To<InputLogSystem>().AsSingle();
        Container.Bind<ISystem>().WithId(FeatureType.Interaction).To<ButtonEventHandlingSystem>().AsSingle();


        Container.Bind<ISystem>().WithId(FeatureType.GameFlow).To<GameInitSystem>().AsSingle();
        Container.Bind<ISystem>().WithId(FeatureType.GameFlow).To<GameViewCreationSystem>().AsSingle();
        Container.Bind<ISystem>().WithId(FeatureType.GameFlow).To<SceneManagementSystem>().AsSingle();
        Container.Bind<ISystem>().WithId(FeatureType.GameFlow).To<GameModeSystem>().AsSingle();
        Container.Bind<ISystem>().WithId(FeatureType.GameFlow).To<GridPositioningSystem>().AsSingle();
        Container.Bind<ISystem>().WithId(FeatureType.GameFlow).To<GridSelectionSystem>().AsSingle();
        Container.Bind<ISystem>().WithId(FeatureType.GameFlow).To<ToolboxViewCreationSystem>().AsSingle();
        Container.Bind<ISystem>().WithId(FeatureType.GameFlow).To<ToolboxManagementSystem>().AsSingle();
        Container.Bind<ISystem>().WithId(FeatureType.GameFlow).To<GridPhysicsObjectCreationSystem>().AsSingle();
       

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