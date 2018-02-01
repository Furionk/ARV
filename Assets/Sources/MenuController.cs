// AREA.ARV - AREA.ARV - i_MenuController.cs
// Created at: 2018 01 14 上午 11:01
// Updated At: 2018 01 21 下午 06:39
// By: Furion Mashiou

using UnityEngine;
using UnityEngine.Assertions;

public class MenuController : MonoBehaviour {

    #region Fields

    private string _previousPanel;

    #endregion

    #region Methods

    public void SwitchPanel(string panelName) {
        HidePanel(_previousPanel);
        ShowPanel(panelName);
        _previousPanel = panelName;
    }

    public void TogglePanel(string panelName) {
        var panel = transform.Find(panelName);
        if (panel.gameObject.activeInHierarchy) {
            HidePanel(panelName);
        } else {
            ShowPanel(panelName, false);
        }
    }

    public void ShowPanel(string panelName, bool resetPosition = true) {
        var panel = transform.Find(panelName);
        Assert.IsNotNull(panel);
        if (resetPosition) panel.localPosition = Vector3.zero;
        panel.gameObject.SetActive(true);
    }

    public void HidePanel(string panelName) {
        var panel = transform.Find(panelName);
        Assert.IsNotNull(panel);
        panel.gameObject.SetActive(false);
    }

    private void Awake() {
        _previousPanel = transform.GetChild(0).name;
        for (var i = 1; i < transform.childCount; i++) {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    #endregion

}