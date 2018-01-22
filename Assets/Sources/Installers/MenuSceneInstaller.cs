using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

public class MenuSceneInstaller : MonoInstaller<MenuSceneInstaller> {
    public override void InstallBindings() {
        Container.Bind<MenuController>().FromInstance(GameObject.FindObjectOfType<MenuController>());
        Debug.Log("[Zenject] Menu Scene Installed");
    }
}