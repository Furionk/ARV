//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public OnMouseDownComponent onMouseDown { get { return (OnMouseDownComponent)GetComponent(InputComponentsLookup.OnMouseDown); } }
    public bool hasOnMouseDown { get { return HasComponent(InputComponentsLookup.OnMouseDown); } }

    public void AddOnMouseDown(float newX, float newY) {
        var index = InputComponentsLookup.OnMouseDown;
        var component = CreateComponent<OnMouseDownComponent>(index);
        component.x = newX;
        component.y = newY;
        AddComponent(index, component);
    }

    public void ReplaceOnMouseDown(float newX, float newY) {
        var index = InputComponentsLookup.OnMouseDown;
        var component = CreateComponent<OnMouseDownComponent>(index);
        component.x = newX;
        component.y = newY;
        ReplaceComponent(index, component);
    }

    public void RemoveOnMouseDown() {
        RemoveComponent(InputComponentsLookup.OnMouseDown);
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
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherOnMouseDown;

    public static Entitas.IMatcher<InputEntity> OnMouseDown {
        get {
            if (_matcherOnMouseDown == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.OnMouseDown);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherOnMouseDown = matcher;
            }

            return _matcherOnMouseDown;
        }
    }
}
