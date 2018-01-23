using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;
using Zenject;

public enum FeatureType {

    All,
    GameFlow,
    Interaction

}

public class GameFlow : Feature {

    public GameFlow(DiContainer container) : base(FeatureType.GameFlow.ToString()) {
        foreach (var system in container.ResolveIdAll<ISystem>(FeatureType.GameFlow)) {
            Add(system);
        }
    }

}

public class Interaction : Feature {

    public Interaction(DiContainer container) : base(FeatureType.Interaction.ToString()) {
        foreach (var system in container.ResolveIdAll<ISystem>(FeatureType.Interaction)) {
            Add(system);
        }
    }

}
