using Entitas;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

public class DesignSceneInstaller : MonoInstaller<DesignSceneInstaller> {

    public ARManager m_ARManager;
    public MenuController m_MenuController;
    public Transform m_ToolboxContent;
    public Transform m_PlaceToolButton;

    [Inject]
    private GameContext gameContext;

    public override void InstallBindings() {
        Container.Bind<ARManager>().FromInstance(m_ARManager);
        Container.Rebind<MenuController>().FromInstance(m_MenuController);
        Container.RebindId<Transform>("ToolboxContent").FromInstance(m_ToolboxContent);
        Container.RebindId<Transform>("PlaceToolButton").FromInstance(m_PlaceToolButton);
        foreach (var system in Container.ResolveIdAll<ISystem>(FeatureType.All)) {
            Container.Inject(system);
        }
        m_PlaceToolButton.gameObject.SetActive(false);

        Container.InstantiatePrefab(Resources.Load<GameObject>("ARCamera"));
        gameContext.CreateEntity().AddVehiclePart("Wheel", Vector3.zero);
        gameContext.CreateEntity().AddVehiclePart("Wheel", Vector3.zero);
        gameContext.CreateEntity().AddVehiclePart("Wheel", Vector3.zero);
        gameContext.CreateEntity().AddVehiclePart("Wheel", Vector3.zero);
        gameContext.CreateEntity().AddVehiclePart("WoodBody", Vector3.zero);
        gameContext.CreateEntity().AddVehiclePart("WoodBody", Vector3.zero);
        gameContext.CreateEntity().AddVehiclePart("WoodBody", Vector3.zero);
        gameContext.CreateEntity().AddVehiclePart("WoodBody", Vector3.zero);

        Debug.Log("[Zenject] Design Scene Installed");
    }
}