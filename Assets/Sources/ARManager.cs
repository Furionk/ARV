/*===============================================================================
Copyright (c) 2017 PTC Inc. All Rights Reserved.

Confidential and Proprietary - Protected under copyright and other laws.
Vuforia is a trademark of PTC Inc., registered in the United States and other 
countries.
===============================================================================*/

using System.Collections.Generic;
using Entitas.Unity;
using UnityEngine;
using Vuforia;
using Zenject;

public class ARManager : MonoBehaviour {

    [Inject]
    private GameContext _gameContext;

    #region PUBLIC_MEMBERS
    public PlaneFinderBehaviour m_PlaneFinder;
    public GameObject m_ARArea;
    public UnityEngine.UI.Text m_OnScreenMessage;
    public GameObject m_Toolbox;
    public CanvasGroup m_GroundReticle;
    public GameObject m_confirmButton;
    #endregion // PUBLIC_MEMBERS


    #region PRIVATE_MEMBERS
    PositionalDeviceTracker positionalDeviceTracker;
    ContentPositioningBehaviour contentPositioningBehaviour;
    GameObject m_PlaneAnchor;
    AnchorBehaviour[] anchorBehaviours;
    StateManager stateManager;
    int AutomaticHitTestFrameCount;
    private Camera mainCamera;

    #endregion // PRIVATE_MEMBERS


    #region MONOBEHAVIOUR_METHODS

    void Awake() {
        Reset();
    }

    void Start() {
        Debug.Log("Start() called.");
        VuforiaARController.Instance.RegisterVuforiaStartedCallback(OnVuforiaStarted);
        VuforiaARController.Instance.RegisterOnPauseCallback(OnVuforiaPaused);
        DeviceTrackerARController.Instance.RegisterTrackerStartedCallback(OnTrackerStarted);
        DeviceTrackerARController.Instance.RegisterDevicePoseStatusChangedCallback(OnDevicePoseStatusChanged);

        m_PlaneFinder.HitTestMode = HitTestMode.AUTOMATIC;
        mainCamera = Camera.main;
    }


    void OnDestroy() {
        Debug.Log("OnDestroy() called.");

        VuforiaARController.Instance.UnregisterVuforiaStartedCallback(OnVuforiaStarted);
        VuforiaARController.Instance.UnregisterOnPauseCallback(OnVuforiaPaused);
        DeviceTrackerARController.Instance.UnregisterTrackerStartedCallback(OnTrackerStarted);
        DeviceTrackerARController.Instance.UnregisterDevicePoseStatusChangedCallback(OnDevicePoseStatusChanged);
    }



    void LateUpdate() {
        if (AutomaticHitTestFrameCount == Time.frameCount) {
            // We got an automatic hit test this frame
            m_GroundReticle.alpha = 0; // hide the onscreen reticle
            m_OnScreenMessage.enabled = false; // hide the onscreen message
            m_Toolbox.SetActive(true);
            SetSurfaceIndicatorVisible(true); // display the surface indicator
            m_ARArea.SetActive(true);
        } else {
            // No automatic hit test, so set alpha based on which plane mode is active
            // m_GroundReticle.alpha = (planeMode == PlaneMode.GROUND) ? 1 : 0;
            m_Toolbox.SetActive(false);
            m_OnScreenMessage.enabled = true;
            m_ARArea.SetActive(false);
            SetSurfaceIndicatorVisible(false);
        }
    }

    #endregion // MONOBEHAVIOUR_METHODS

    #region VUFORIA_CALLBACKS

    void OnVuforiaStarted() {
        Debug.Log("OnVuforiaStarted() called.");

        stateManager = TrackerManager.Instance.GetStateManager();
    }

    void OnVuforiaPaused(bool paused) {
        Debug.Log("OnVuforiaPaused(" + paused.ToString() + ") called.");

        if (paused)
            Reset();
    }

    #endregion // VUFORIA_CALLBACKS


    #region PRIVATE_METHODS

    void SetSurfaceIndicatorVisible(bool isVisible) {
        Renderer[] renderers = m_PlaneFinder.PlaneIndicator.GetComponentsInChildren<Renderer>(true);
        Canvas[] canvas = m_PlaneFinder.PlaneIndicator.GetComponentsInChildren<Canvas>(true);

        foreach (Canvas c in canvas)
            c.enabled = isVisible;

        foreach (Renderer r in renderers)
            r.enabled = isVisible;
    }

    private void RotateTowardCamera(GameObject augmentation) {
        var lookAtPosition = mainCamera.transform.position - augmentation.transform.position;
        lookAtPosition.y = 0;
        var rotation = Quaternion.LookRotation(lookAtPosition);
        augmentation.transform.rotation = rotation;
    }

    #endregion // PRIVATE_METHODS

    #region PUBLIC_METHODS

    public void HandleAutomaticHitTest(HitTestResult result) {
        //Debug.Log("Result: " + result.Position);
        AutomaticHitTestFrameCount = Time.frameCount;

    }

    public void Reset() {
        Debug.Log("Reset() called.");
        m_ARArea.transform.position = Vector3.zero;
        m_ARArea.transform.localEulerAngles = Vector3.zero;
        m_ARArea.SetActive(false);
    }

    #endregion // PUBLIC_METHODS


    #region DEVICE_TRACKER_CALLBACKS

    void OnTrackerStarted() {
        Debug.Log("OnTrackerStarted() called.");

        positionalDeviceTracker = TrackerManager.Instance.GetTracker<PositionalDeviceTracker>();

        if (positionalDeviceTracker != null) {
            if (!positionalDeviceTracker.IsActive)
                positionalDeviceTracker.Start();

            Debug.Log("PositionalDeviceTracker is Active?: " + positionalDeviceTracker.IsActive);
        }
    }

    void OnDevicePoseStatusChanged(TrackableBehaviour.Status status) {
        if (status == TrackableBehaviour.Status.TRACKED) {

        }
        Debug.Log("OnDevicePoseStatusChanged(" + status.ToString() + ")");
    }

    #endregion // DEVICE_TRACKER_CALLBACK_METHODS


    //////////public void HandleInteractiveHitTest(HitTestResult result) {
    //////////    Debug.Log("HandleInteractiveHitTest() called.");

    //////////    if (result == null) {
    //////////        Debug.LogError("Invalid hit test result!");
    //////////        return;
    //////////    }

    //////////    // Place object based on Ground Plane mode
    //////////    if (positionalDeviceTracker != null && positionalDeviceTracker.IsActive) {
    //////////        DestroyAnchors();

    //////////        contentPositioningBehaviour = m_PlaneFinder.GetComponent<ContentPositioningBehaviour>();
    //////////        contentPositioningBehaviour.PositionContentAtPlaneAnchor(result);
    //////////    }

    //////////    if (!m_ARArea.activeInHierarchy) {
    //////////        Debug.Log("Setting Plane Augmentation to Active");
    //////////        // On initial run, unhide the augmentation
    //////////        m_ARArea.SetActive(true);
    //////////    }

    //////////    Debug.Log("Positioning Plane Augmentation at: " + result.Position);
    //////////    m_ARArea.PositionAt(result.Position);
    //////////    RotateTowardCamera(m_ARArea);
    //////////}
    /// 

    //////////private void DestroyAnchors() {
    //////////    IEnumerable<TrackableBehaviour> trackableBehaviours = stateManager.GetActiveTrackableBehaviours();

    //////////    string destroyed = "Destroying: ";

    //////////    foreach (TrackableBehaviour behaviour in trackableBehaviours) {
    //////////        if (behaviour is AnchorBehaviour) {
    //////////            // First determine which mode (Plane or MidAir) and then delete only the anchors for that mode
    //////////            // Leave the other mode's anchors intact
    //////////            // PlaneAnchor_<GUID>
    //////////            // Mid AirAnchor_<GUID>

    //////////            if ((behaviour.Trackable.Name.Contains("PlaneAnchor"))) {
    //////////                destroyed +=
    //////////                    "\nGObj Name: " + behaviour.name +
    //////////                    "\nTrackable Name: " + behaviour.Trackable.Name +
    //////////                    "\nTrackable ID: " + behaviour.Trackable.ID +
    //////////                    "\nPosition: " + behaviour.transform.position.ToString();

    //////////                stateManager.DestroyTrackableBehavioursForTrackable(behaviour.Trackable);
    //////////                stateManager.ReassociateTrackables();
    //////////            }
    //////////        }
    //////////    }

    //////////    Debug.Log(destroyed);
    //////////}

}
