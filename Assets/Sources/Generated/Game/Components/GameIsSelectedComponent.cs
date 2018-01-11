//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public IsSelectedComponent isSelected { get { return (IsSelectedComponent)GetComponent(GameComponentsLookup.IsSelected); } }
    public bool hasIsSelected { get { return HasComponent(GameComponentsLookup.IsSelected); } }

    public void AddIsSelected(int newEntityId) {
        var index = GameComponentsLookup.IsSelected;
        var component = CreateComponent<IsSelectedComponent>(index);
        component.EntityId = newEntityId;
        AddComponent(index, component);
    }

    public void ReplaceIsSelected(int newEntityId) {
        var index = GameComponentsLookup.IsSelected;
        var component = CreateComponent<IsSelectedComponent>(index);
        component.EntityId = newEntityId;
        ReplaceComponent(index, component);
    }

    public void RemoveIsSelected() {
        RemoveComponent(GameComponentsLookup.IsSelected);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherIsSelected;

    public static Entitas.IMatcher<GameEntity> IsSelected {
        get {
            if (_matcherIsSelected == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.IsSelected);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherIsSelected = matcher;
            }

            return _matcherIsSelected;
        }
    }
}
