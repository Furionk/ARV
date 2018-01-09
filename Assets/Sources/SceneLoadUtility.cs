using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Vuforia;
using Zenject;

public class SceneLoadUtility : MonoBehaviour {

    [Inject]
    public GameContext _gameContext;

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
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    for (int k = 0; k < 3; k++) {
                        _gameContext.CreateEntity().AddGrid(new Vector3(i, j, k));
                    }
                }
            }
        }
    }


}
