using UnityEngine;
using System.Collections;
using Entitas;
using Entitas.CodeGeneration.Attributes;

public enum GameMode {

    Menu,
    Design,
    Simulation

}

[Game, Unique]
public class GameModeComponent : IComponent {

    public GameMode gameMode;

}
