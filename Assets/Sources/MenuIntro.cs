using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

public class MenuIntro : MonoBehaviour {


    [Inject(Id = "GlobalPanel")]
    private RectTransform _globalPanel;
    private bool _animationPlayed;

    void Awake() {
        this.transform.localPosition = Vector3.zero;
    }

    public void HandleIntroAnimationPlayed() {
        _animationPlayed = true;
    }

    public void Update() {
        if (Input.anyKey) {
            if (_animationPlayed) {
                _globalPanel.gameObject.SetActive(true);
                this.gameObject.SetActive(false);
            }
        }

    }

}
