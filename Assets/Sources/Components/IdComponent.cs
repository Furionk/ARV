using System;
using UnityEngine;
using System.Collections;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Input]
public class IdComponent : IComponent {

    [PrimaryEntityIndex]
    public int Id;

}
