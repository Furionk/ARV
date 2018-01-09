using System.Collections.Generic;
using Entitas.Unity;
using UnityEngine;
using Vuforia;
using Zenject;

public class ARCursor : MonoBehaviour {

    [Inject(Id = "GridLayer")]
    private LayerMask _gridLayerMask;

    [Inject]
    private GameContext _gameContext;

    private Vector3 _screenCenter;
    private Material _mGridSelected;

    void Awake() {
        _screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0);
        _mGridSelected = Resources.Load<Material>("Game/Grid Selected");
        Debug.Log("Screen center = " + _screenCenter);
    }

    void Update() {

        Ray hitRay = Camera.main.ScreenPointToRay(_screenCenter);
        Debug.DrawRay(hitRay.origin, hitRay.direction, Color.yellow, 1f);
        RaycastHit[] hitInfo = Physics.RaycastAll(hitRay, 5, _gridLayerMask);
        if (hitInfo.Length > 0) {
            for (int i = 0;i < hitInfo.Length;i++) {
                Debug.Log("HIT!");
                GameEntity ge = hitInfo[i].transform.gameObject.GetEntityLink().entity as GameEntity;
                if (ge.hasGrid) {

                    hitInfo[i].transform.GetComponent<MeshRenderer>().material = _mGridSelected;


                }
            }

        }



    }

}
