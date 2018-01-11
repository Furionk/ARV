//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public IdComponent id { get { return (IdComponent)GetComponent(InputComponentsLookup.Id); } }
    public bool hasId { get { return HasComponent(InputComponentsLookup.Id); } }

    public void AddId(int newId) {
        var index = InputComponentsLookup.Id;
        var component = CreateComponent<IdComponent>(index);
        component.Id = newId;
        AddComponent(index, component);
    }

    public void ReplaceId(int newId) {
        var index = InputComponentsLookup.Id;
        var component = CreateComponent<IdComponent>(index);
        component.Id = newId;
        ReplaceComponent(index, component);
    }

    public void RemoveId() {
        RemoveComponent(InputComponentsLookup.Id);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity : IId { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherId;

    public static Entitas.IMatcher<InputEntity> Id {
        get {
            if (_matcherId == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.Id);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherId = matcher;
            }

            return _matcherId;
        }
    }
}
