using System.Collections.Generic;
using Entitas.Unity;
using UnityEngine;
using Vuforia;
using Zenject;

public class ARCursor : MonoBehaviour {

    [Inject(Id = "GridLayer")]
    private LayerMask _gridLayerMask;

    [Inject(Id = "DetectDistance")]
    private float _detectDistance;

    [Inject]
    private GameContext _gameContext;


    private int _lastTargetEntityIndex = -1;
    private int[] _lastMiddleEntityIndexs;
    private Vector3 _screenCenter;

    void Awake() {
        _screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0);
        Debug.Log("Screen center = " + _screenCenter);
    }

    void Update() {
        int finalHitIndex = -1;
        Ray hitRay = Camera.main.ScreenPointToRay(_screenCenter);
        Debug.DrawRay(hitRay.origin, hitRay.direction, Color.yellow, 1f);
        RaycastHit[] hitInfo = Physics.RaycastAll(hitRay, _detectDistance, _gridLayerMask);
        Vector3 maxDisVec = Vector3.zero;
        Vector3 cameraPosition = this.transform.position;
        if (hitInfo.Length > 0) {
            for (int i = 0; i < hitInfo.Length; i++) {
                Vector3 currentDisVec = hitInfo[i].transform.position - cameraPosition;
                if (currentDisVec.magnitude > maxDisVec.magnitude) {
                    maxDisVec = currentDisVec;
                    finalHitIndex = i;
                }
            }
        }
        if (finalHitIndex != -1) {
            int targetIndex = hitInfo[finalHitIndex].transform.gameObject.GetEntityLink().entity.creationIndex;
            if (_lastTargetEntityIndex != targetIndex) {
                if (_lastTargetEntityIndex != -1 && _gameContext.GetEntityWithId(_lastTargetEntityIndex).hasIsSelected) {
                    _gameContext.GetEntityWithId(_lastTargetEntityIndex).RemoveIsSelected();
                }
                _gameContext.GetEntityWithId(targetIndex).AddIsSelected(0);
                _lastTargetEntityIndex = targetIndex;
            }

            Vector3 disToTarget = hitInfo[finalHitIndex].transform.position - cameraPosition;
            Collider[] insideInfo = Physics.OverlapSphere(hitRay.origin, disToTarget.sqrMagnitude, _gridLayerMask);
            //RaycastHit[] insideInfo = Physics.SphereCastAll(hitRay, disToTarget.sqrMagnitude, 100, _gridLayerMask);
            //RaycastHit[] insideInfo = Physics.BoxCastAll(hitRay.origin, (disToTarget / 2), hitRay.direction, Quaternion.identity, 100, _gridLayerMask);
            //Gizmos.DrawCube(hitRay.origin, disToTarget/2);
            if (insideInfo.Length > 0) {
                Debug.Log("HIT" + insideInfo.Length);
                for (int i = 0;
                    i < insideInfo.Length;
                    i++) {
                    int index = insideInfo[i].transform.gameObject.GetEntityLink().entity.creationIndex;

                    //_gameContext.GetEntityWithId(index).add
                }
            }

        } else {
            if (_lastTargetEntityIndex != -1) {
                _gameContext.GetEntityWithId(_lastTargetEntityIndex).RemoveIsSelected();
                _lastTargetEntityIndex = -1;
            }
        }

    }

}
