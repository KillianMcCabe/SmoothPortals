using UnityEngine;
using System.Collections;

public class Sender : MonoBehaviour {

    public GameObject player;
    public GameObject receiver;

    private float prevDot = 0;
    private bool playerOverlapping = false;

    void Start () {
    }

    void Update()
    {
        if (playerOverlapping) {
            var currentDot = Vector3.Dot(transform.up, player.transform.position - transform.position);

            if (currentDot < 0) // only transport the player once he's moved across plane
            {
                teleport();
                playerOverlapping = false;
            }
               
            prevDot = currentDot;
        }
    }

    // transport player to the equivalent position in the other portal
    private void teleport()
    {
        // get relative difference between two rotations (i.e. the quaternion that would turn this rotation into that rotation)
        // so say we want diff which multiplying q1 by would give us q2 then..
        // diff* q1 = q2--->diff = q2 * inverse(q1)
        Quaternion relativeDiff = receiver.transform.rotation * Quaternion.Inverse(transform.rotation);
        relativeDiff *= Quaternion.Euler(0, 180, 0);
        
        Vector3 positionOffset = player.transform.position - transform.position;
        positionOffset = relativeDiff * positionOffset;
        player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().Rotate(relativeDiff);
        
        player.transform.position = receiver.transform.position + positionOffset;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerOverlapping = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerOverlapping = false;
        }
    }
}
