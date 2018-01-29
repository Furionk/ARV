using Entitas;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

public class DesignSceneInstaller : MonoInstaller<DesignSceneInstaller> {

    public ARManager m_ARManager;
    public MenuController m_MenuController;

    public Transform m_ToolboxContent;
    public Transform m_PlaceToolButton;
    public Transform m_ARFunctionBar;

    [Inject]
    private GameContext gameContext;

    public override void InstallBindings() {
        Container.Bind<ARManager>().FromInstance(m_ARManager);
        Container.Rebind<MenuController>().FromInstance(m_MenuController);
        Container.RebindId<Transform>("ToolboxContent").FromInstance(m_ToolboxContent);
        Container.RebindId<Transform>("PlaceToolButton").FromInstance(m_PlaceToolButton);
        Container.RebindId<Transform>("ARFunctionBar").FromInstance(m_ARFunctionBar);

        // reinject to all systems
        foreach (var system in Container.ResolveIdAll<ISystem>(FeatureType.All)) {
            Container.Inject(system);
        }

        Container.InstantiatePrefab(Resources.Load<GameObject>("ARCamera"));
        gameContext.CreateEntity().AddVehicleTool(VehicleTool.Wheel);
        gameContext.CreateEntity().AddVehicleTool(VehicleTool.Wheel);
        gameContext.CreateEntity().AddVehicleTool(VehicleTool.Wheel);
        gameContext.CreateEntity().AddVehicleTool(VehicleTool.Wheel);
        gameContext.CreateEntity().AddVehicleTool(VehicleTool.WoodBody);
        gameContext.CreateEntity().AddVehicleTool(VehicleTool.WoodBody);
        gameContext.CreateEntity().AddVehicleTool(VehicleTool.WoodBody);
        gameContext.CreateEntity().AddVehicleTool(VehicleTool.WoodBody);

        m_ARFunctionBar.gameObject.SetActive(false);
        m_PlaceToolButton.gameObject.SetActive(false);

        Debug.Log("[Zenject] Design Scene Installed");
    }
}