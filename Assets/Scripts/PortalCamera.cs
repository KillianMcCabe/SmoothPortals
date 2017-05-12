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
        var portalPos = portal.transform.position;
        var otherPortalPos = otherPortal.transform.position;
        var playerCameraPos = playerCamera.transform.position;

        // adjust position of camera
        var playerOffsetFromPortal = playerCameraPos - otherPortalPos;
        transform.position = portalPos + playerOffsetFromPortal;

        // adjust rotation of camera
        var anglarDifferenceBetweenPortalRotations = Quaternion.Angle(portal.transform.rotation, otherPortal.transform.rotation);
        var portalRotationalDifference = Quaternion.AngleAxis(anglarDifferenceBetweenPortalRotations, Vector3.up);
        var newFacing = portalRotationalDifference * playerCamera.transform.forward;
        transform.rotation = Quaternion.LookRotation(newFacing, Vector3.up);
    }
}
