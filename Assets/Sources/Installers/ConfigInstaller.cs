using System;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "ConfigInstaller", menuName = "Installers/ConfigInstaller")]
public class ConfigInstaller : ScriptableObjectInstaller<ConfigInstaller> {

    public float offset;
    public LayerMask gridLayer;
    public float detectDistance;

    public override void InstallBindings() {
        Container.Bind<float>().WithId("Offset").FromInstance(offset);
        Container.Bind<LayerMask>().WithId("GridLayer").FromInstance(gridLayer);
        Container.Bind<float>().WithId("DetectDistance").FromInstance(detectDistance);
    }
}