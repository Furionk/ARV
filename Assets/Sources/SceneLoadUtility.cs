using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Vuforia;

public class SceneLoadUtility : MonoBehaviour {

    public void Awake() {
        StartCoroutine("DirectLoad", SceneManager.GetActiveScene().name);
    }

    public void LoadScene(string targetScene) {
        StartCoroutine("LoadProcess", targetScene);
    }

    private IEnumerator LoadProcess(string targetScene) {
        var activeSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadSceneAsync("Loading", LoadSceneMode.Additive);
        yield return new WaitForSeconds(3f);
        SceneManager.UnloadSceneAsync(activeSceneName);
        yield return PreProcess(targetScene);
        var async = SceneManager.LoadSceneAsync(targetScene, LoadSceneMode.Additive);
        while (!async.isDone) {
            yield return null;
        }
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(targetScene));
        SceneManager.UnloadSceneAsync("Loading");
        AfterProcess(targetScene);
    }

    private IEnumerator DirectLoad(string targetScene) {
        yield return PreProcess(targetScene);
        AfterProcess(targetScene);
        yield return null;
    }

    public IEnumerator PreProcess(string targetScene) {
        Debug.Log("[LOAD] PRE process " + targetScene);
        if (targetScene == "Design") {
            VuforiaManager.Instance.Init();
            while (!VuforiaManager.Instance.Initialized) {
                yield return null;
            }
            Debug.Log("Vuforia Inited");
        }
    }

    public void AfterProcess(string targetScene) {
        Debug.Log("[LOAD] AFT process " + targetScene);
        if (targetScene == "Design") {
            GameObject.Instantiate(Resources.Load<GameObject>("ARCamera"));
        }
    }

}
