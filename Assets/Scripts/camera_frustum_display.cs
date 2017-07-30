using UnityEngine;
using System.Collections;

public class camera_frustum_display : MonoBehaviour {
	
	//public Transform[] Corners;
	

	
	Camera theCam;
	
	void Start () {	theCam = GetComponent<Camera>(); }

	void Update() {
		//CullCameraFrustum ();
	}


}
