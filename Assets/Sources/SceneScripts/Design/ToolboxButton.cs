using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ToolboxButton : MonoBehaviour {

    [Inject]
    private MenuController MenuController;

    public void HandleReset() {
        MenuController.ShowPanel("pnl_toolbox");
    }
}
