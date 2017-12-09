using UnityEngine;
using System.Collections;

public class PortalCamera : MonoBehaviour {

    public GameObject playerCamera;
    public GameObject portal;
    public GameObject otherPortal;
    

    // Use this for initialization
    void Start () {
        if (playerCamera == null)
        {
            // if no reference is set up then we will try to find it
            playerCamera = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Camera>().gameObject; ;
            if (playerCamera == null)
            {
                print("cannot find player camera");
            }
            
        }
	
	}
	
	// Each frame reposition the camera to mimic the players offset from the other portals position
	void LateUpdate () {
		
		Vector3 portalPos = portal.transform.position;
		Vector3 otherPortalPos = otherPortal.transform.position;
		Vector3 playerCameraPos = playerCamera.transform.position;

        // adjust rotation of camera
        Quaternion differenceInPortalRotations = Quaternion.Inverse(otherPortal.transform.rotation) * portal.transform.rotation; // calculate quaternion needed to rotate between one portal and the other
        Vector3 newFacingDirection = differenceInPortalRotations * playerCamera.transform.forward;
        transform.rotation = Quaternion.LookRotation(newFacingDirection, Vector3.up);

        // adjust position of camera
        Vector3 playerOffsetFromPortal = playerCameraPos - otherPortalPos;
        playerOffsetFromPortal = differenceInPortalRotations * playerOffsetFromPortal;
        transform.position = portalPos + playerOffsetFromPortal;
        
    }
}
