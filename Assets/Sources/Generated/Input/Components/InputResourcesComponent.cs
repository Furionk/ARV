//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public ResourcesComponent resources { get { return (ResourcesComponent)GetComponent(InputComponentsLookup.Resources); } }
    public bool hasResources { get { return HasComponent(InputComponentsLookup.Resources); } }

    public void AddResources(string newPrefabPath) {
        var index = InputComponentsLookup.Resources;
        var component = CreateComponent<ResourcesComponent>(index);
        component.prefabPath = newPrefabPath;
        AddComponent(index, component);
    }

    public void ReplaceResources(string newPrefabPath) {
        var index = InputComponentsLookup.Resources;
        var component = CreateComponent<ResourcesComponent>(index);
        component.prefabPath = newPrefabPath;
        ReplaceComponent(index, component);
    }

    public void RemoveResources() {
        RemoveComponent(InputComponentsLookup.Resources);
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
public partial class InputEntity : IResources { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherResources;

    public static Entitas.IMatcher<InputEntity> Resources {
        get {
            if (_matcherResources == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.Resources);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherResources = matcher;
            }

            return _matcherResources;
        }
    }
}
