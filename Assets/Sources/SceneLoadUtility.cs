using System;
using UnityEngine;
using System.Collections;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using UnityEngine.SceneManagement;
using Vuforia;
using Zenject;

public class SceneLoadUtility : MonoBehaviour {

    [Inject]
    private GameContext _gameContext;

    [Inject]
    private DiContainer _container;

    public void Awake() {
        StartCoroutine("DirectLoad", SceneManager.GetActiveScene().name);
    }

    public void LoadScene(string targetScene) {
        StartCoroutine("LoadProcess", targetScene);
    }

    private IEnumerator LoadProcess(string targetScene) {
        var activeSceneName = SceneManager.GetActiveScene().name;
        var async1 = SceneManager.LoadSceneAsync("Loading", LoadSceneMode.Single);
        while (!async1.isDone) {
            yield return null;
        }
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName("Loading"));
        //yield return new WaitForSeconds(3f);
        var async = SceneManager.LoadSceneAsync(targetScene, LoadSceneMode.Additive);
        yield return PreProcess(targetScene);
        while (!async.isDone) {
            yield return null;
        }
        yield return new WaitForSeconds(3f);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(targetScene));
        var async3 = SceneManager.UnloadSceneAsync("Loading");
        while (!async3.isDone) {
            yield return null;
        }
        yield return null;
        AfterProcess(targetScene);
    }

    private IEnumerator DirectLoad(string targetScene) {
        yield return PreProcess(targetScene);
        AfterProcess(targetScene);
        yield return null;
    }

    public IEnumerator PreProcess(string targetScene) {
        Debug.Log("[SceneLoadUtility] PRE process " + targetScene);
        if (targetScene == "Design") {
            VuforiaManager.Instance.Init();
            while (!VuforiaManager.Instance.Initialized) {
                yield return null;
            }
            Debug.Log("[SceneLoadUtility] Vuforia Inited");
        }
    }

    public void AfterProcess(string targetScene) {
        Debug.Log("[SceneLoadUtility] AFT process " + targetScene);
        if (targetScene == "Design") {

            //_gameContext.CreateEntity().AddVehiclePart("Wheel", Vector3.zero);
            //_gameContext.CreateEntity().AddVehiclePart("Wheel", Vector3.zero);
            //_gameContext.CreateEntity().AddVehiclePart("Wheel", Vector3.zero);
            //_gameContext.CreateEntity().AddVehiclePart("Wheel", Vector3.zero);

            //_gameContext.CreateEntity().AddVehiclePart("WoodBody", Vector3.zero);
            //_gameContext.CreateEntity().AddVehiclePart("WoodBody", Vector3.zero);
            //_gameContext.CreateEntity().AddVehiclePart("WoodBody", Vector3.zero);
            //_gameContext.CreateEntity().AddVehiclePart("WoodBody", Vector3.zero);

        }



    }

}
