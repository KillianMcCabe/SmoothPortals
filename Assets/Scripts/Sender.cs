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
        float rotDiff = -Quaternion.Angle(transform.rotation, receiver.transform.rotation);
        rotDiff += 180;
        //player.transform.Rotate(Vector3.up, rotDiff); // I dont think this is working
        

        Vector3 positionOffset = player.transform.position - transform.position;
        positionOffset = Quaternion.Euler(0, rotDiff, 0) * positionOffset;

        // dont forget that the two portals might not share the same rotation
        Quaternion relative = Quaternion.Inverse(transform.rotation) * receiver.transform.rotation; // get relative difference between two rotations
        Quaternion relative2 = Quaternion.Inverse(receiver.transform.rotation) * transform.rotation; // get relative difference between two rotations

        Quaternion q = Quaternion.Euler(0, -rotDiff, 0);

        //player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().Rotate(q);

        //positionOffset = relative * positionOffset;
        player.transform.position = receiver.transform.position + positionOffset;
        
        //player.transform.rotation *= relative;
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
