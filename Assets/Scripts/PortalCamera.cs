using UnityEngine;
using System.Collections;

public class PortalCamera : MonoBehaviour {

    public GameObject playerCamera;
    public GameObject portal;
    public GameObject otherPortal;
    

    // Use this for initialization
    void Start () {
	
	}
	
	// Each frame reposition the camera to mimic the players offset from the other portals position
	void Update () {
		Vector3 portalPos = portal.transform.position;
		Vector3 otherPortalPos = otherPortal.transform.position;
		Vector3 playerCameraPos = playerCamera.transform.position;
        
		float anglarDifferenceBetweenPortalRotations = Quaternion.Angle(portal.transform.rotation, otherPortal.transform.rotation);
		Quaternion portalRotationalDifference = Quaternion.AngleAxis(anglarDifferenceBetweenPortalRotations, Vector3.up);

        //Quaternion relative = Quaternion.Inverse(portal.transform.rotation) * otherPortal.transform.rotation; // get relative difference between two rotations
        Quaternion relative = Quaternion.Inverse(otherPortal.transform.rotation) * portal.transform.rotation; // get relative difference between two rotations

        // adjust position of camera
        Vector3 playerOffsetFromPortal = playerCameraPos - otherPortalPos;
        playerOffsetFromPortal = relative * playerOffsetFromPortal;
        transform.position = portalPos + playerOffsetFromPortal;

        // adjust rotation of camera
        Vector3 newFacingDirection = relative * playerCamera.transform.forward;
        transform.rotation = Quaternion.LookRotation(newFacingDirection, Vector3.up);
    }
}
