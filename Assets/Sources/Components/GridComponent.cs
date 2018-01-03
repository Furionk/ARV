using UnityEngine;
using System.Collections;
using Entitas;
using Entitas.CodeGeneration.Attributes;

public class GridComponent : IComponent {

    [EntityIndex]
    public Vector3 position;

}
