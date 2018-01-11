using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine.SceneManagement;
using Vuforia;
using Zenject;

public class GameController : MonoBehaviour {

    [Inject]
    public List<Feature> features;

    private Systems _systems;

    void Awake() {
    }

    // Use this for initialization
    void Start() {
        Contexts ctxs = Contexts.sharedInstance;

        foreach (var context in ctxs.allContexts) {
            if (context.contextInfo.componentTypes.Contains(typeof(IdComponent))) {
                context.OnEntityCreated += AddId;
            }
        }

        _systems = new Feature("Root Systems");
        foreach (var feature in features) {
            Debug.Log("[I] Feature Loaded: " + feature.ToString());
            _systems.Add(feature);
        }

        _systems.Initialize();
    }

    // Update is called once per frame
    void Update() {
        _systems.Execute();
        _systems.Cleanup();
    }


    private void AddId(IContext context, IEntity entity) {
        (entity as IId).AddId(entity.creationIndex);
    }
}
