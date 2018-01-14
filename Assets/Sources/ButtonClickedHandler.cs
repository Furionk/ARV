using UnityEngine;
using System.Collections;
using Entitas;
using Zenject;

public class ButtonClickedHandler : MonoBehaviour {

    [Inject]
    private InputContext inputContext;

    public string ButtonId;

    public void OnButtonClicked() {
        if (string.IsNullOrEmpty(ButtonId)) {
            inputContext.CreateEntity().AddOnMenuButtonDown(this.gameObject.name);
        } else {
            inputContext.CreateEntity().AddOnMenuButtonDown(ButtonId);
        }
    }

}
