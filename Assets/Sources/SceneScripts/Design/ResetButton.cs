using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ResetButton : MonoBehaviour {

    [Inject]
    private ARManager ARManager;

    public void HandleReset() {
        ARManager.Reset();
    }
}
