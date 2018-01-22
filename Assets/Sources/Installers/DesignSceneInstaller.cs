using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

public class DesignSceneInstaller : MonoInstaller<DesignSceneInstaller> {

    //public ARManager m_ARManager;
    //public MenuController m_MenuController;

    public override void InstallBindings() {
        Container.Bind<ARManager>().FromInstance(FindObjectOfType<ARManager>());
        Container.Rebind<MenuController>().FromInstance(FindObjectOfType<MenuController>());

        Container.Bind<string>().WithId("GoodData").FromInstance("Loading!!!!!");
        Container.InjectGameObject(GameController.Instance.gameObject);
        Debug.Log("[Zenject] Design Scene Installed");
    }
}