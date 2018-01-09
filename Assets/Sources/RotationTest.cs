using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTest : MonoBehaviour {


	// Update is called once per frame
	void FixedUpdate () {
        this.transform.GetComponent<Rigidbody>().AddTorque(Vector3.forward * 60, ForceMode.Force);
		//this.transform.Rotate(Vector3.up * Time.deltaTime * 60);
	}
}
