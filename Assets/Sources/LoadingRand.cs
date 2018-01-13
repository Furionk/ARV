using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingRand : MonoBehaviour {

    private float _elpased;
    private int? _lastChildIndex;
    private int _childCount;

    void Awake() {
        _childCount = this.transform.childCount;
        for (int i = 0; i < _childCount; i++) {
            if (this.transform.GetChild(i).gameObject.activeInHierarchy) {
                _lastChildIndex = i;
            }
        }
    }

	// Update is called once per frame
	void Update () {
	    _elpased += Time.deltaTime;
	    if (_elpased >= 1) {
	        if (Random.Range(0f, 1.0f) > 0.5f) {
                if (_lastChildIndex.HasValue) this.transform.GetChild(_lastChildIndex.Value).gameObject.SetActive(false);
	            _lastChildIndex = Random.Range(0, _childCount);
	            this.transform.GetChild(_lastChildIndex.Value).gameObject.SetActive(true);

	        }
	        _elpased = 0;
	    }
	}
}
