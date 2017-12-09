using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicPosition : MonoBehaviour {

    public Transform mimicThis;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = mimicThis.position;

    }
}
