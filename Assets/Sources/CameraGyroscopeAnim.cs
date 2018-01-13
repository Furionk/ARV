using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGyroscopeAnim : MonoBehaviour {

    private Gyroscope gyro;
    private bool gyroEnable = false;
    private Quaternion rot;

    // Use this for initialization
	void Start () {
	    if (SystemInfo.supportsGyroscope) {
	        gyro = Input.gyro;
	        gyro.enabled = true;
	        gyroEnable = true;
            rot = new Quaternion(0,0,0.1f,0);
	    }
	}
	
	// Update is called once per frame
	void Update () {
	    if (!gyroEnable)
	        return;
	    this.transform.localRotation = gyro.attitude * rot;
	}
}
