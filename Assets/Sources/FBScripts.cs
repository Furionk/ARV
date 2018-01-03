using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Facebook.Unity;

public class FBScripts : MonoBehaviour {

    void Awake() {
        FB.Init(SetInit, OnHideUnity);

    }

    private void SetInit() {
        if (FB.IsLoggedIn) {
            Debug.Log("FB is logged in");
        } else {
            Debug.Log("FB is not logged in");
        }
    }

    private void OnHideUnity(bool isunityshown) {
        if (!isunityshown) {
            Time.timeScale = 0;
        } else {
            Time.timeScale = 1;
        }
    }

    public void FBLogin() { 
        List<string> permissions = new List<string>();
        permissions.Add("public_profile");
        FB.LogInWithReadPermissions(permissions, AuthCallBack);
    }

    private void AuthCallBack(ILoginResult result) {
        if (result.Error != null) {
            Debug.Log(result.Error);
        } else {
            if (FB.IsLoggedIn) {
                Debug.Log("FB is logged in");
            } else {
                Debug.Log("FB is not logged in");
            }
        }

    }

}
