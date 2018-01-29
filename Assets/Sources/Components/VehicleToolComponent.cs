using UnityEngine;
using System.Collections;
using Entitas;
using Entitas.CodeGeneration.Attributes;


public enum VehicleTool {

    Wheel,
    WoodBody

}

[Game]
public class VehicleToolComponent : IComponent {

    public VehicleTool Type;

}
