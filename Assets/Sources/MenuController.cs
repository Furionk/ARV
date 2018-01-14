using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.Assertions;

public class MenuController : MonoBehaviour {

    private string _previousPanel;

    void Awake() {
        _previousPanel = this.transform.GetChild(0).name;
    }

    public void SwitchPanel(string panelName) {
    }

    public void ShowPanel(string panelName) {
        var panel = this.transform.Find(panelName);
        Assert.IsNotNull(panel);
        panel.gameObject.SetActive(true);
    }

    public void HidePanel(string panelName) {
        var panel = this.transform.Find(panelName);
        Assert.IsNotNull(panel);
        panel.gameObject.SetActive(false);
    }

}
