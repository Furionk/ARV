using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

public class MenuIntro : MonoBehaviour {


    [Inject(Id = "GlobalPanel")]
    public RectTransform GlobalPanel;

    public void Update() {
        if (Input.anyKey) {
            //Debug.Log(GlobalPanel == null);
        }

    }

}
