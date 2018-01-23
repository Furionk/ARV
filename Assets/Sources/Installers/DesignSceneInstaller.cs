using Entitas;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

public class DesignSceneInstaller : MonoInstaller<DesignSceneInstaller> {

    public ARManager m_ARManager;
    public MenuController m_MenuController;
    public Transform m_ToolboxContent;

    public override void InstallBindings() {
        Container.Bind<ARManager>().FromInstance(m_ARManager);
        Container.Rebind<MenuController>().FromInstance(m_MenuController);
        Container.RebindId<Transform>("ToolboxContent").FromInstance(m_ToolboxContent);
        foreach (var system in Container.ResolveIdAll<ISystem>(FeatureType.All)) {
            Container.Inject(system);
        }
        Debug.Log("[Zenject] Design Scene Installed");
    }
}