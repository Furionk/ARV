using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

public class DesignSceneInstaller : MonoInstaller<DesignSceneInstaller> {

    //public ARManager m_ARManager;
    //public MenuController m_MenuController;

    public override void InstallBindings() {
        Container.Bind<ARManager>().FromInstance(FindObjectOfType<ARManager>());
        Container.Bind<MenuController>().FromInstance(FindObjectOfType<MenuController>());
        Debug.Log("[Zenject] Design Scene Installed");
    }
}