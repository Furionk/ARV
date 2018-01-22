using UnityEngine;
using System.Collections;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class VehiclePartComponent : IComponent {

    public string Name;
    public Vector3 Position;

}
