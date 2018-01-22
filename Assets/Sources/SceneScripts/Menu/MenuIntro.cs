using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

public class MenuIntro : MonoBehaviour {

    private bool _animationPlayed;

    [Inject]
    private MenuController _menuController;

    void Awake() {
        this.transform.localPosition = Vector3.zero;
    }

    public void HandleIntroAnimationPlayed() {
        _animationPlayed = true;
    }

    public void Update() {
        if (Input.anyKey) {
            if (_animationPlayed) {
                _menuController.ShowPanel("pnl_Global");
                _menuController.SwitchPanel("pnl_LevelSelection");
            }
        }

    }

}
