using UnityEngine;
using System.Collections;

public class Sender : MonoBehaviour {
    
    public GameObject receiver;

    private Portable currentlyOverlappingObject;

    void Start () {
    }

    void FixedUpdate()
    {
        if (currentlyOverlappingObject != null) {
            var currentDot = Vector3.Dot(transform.up, currentlyOverlappingObject.transform.position - transform.position);

            if (currentDot < 0) // only transport the player once he's moved across plane
            {
                currentlyOverlappingObject.Teleport(this.transform, receiver.transform);
                currentlyOverlappingObject = null;
            }
        }
    }

    // transport player to the equivalent position in the other portal
	private void teleport()
    {
        // get relative difference between two rotations (i.e. the quaternion that would turn this rotation into that rotation)
        // so say we want quaternion d which we can use like so: d * q1 = q2
        // knowing how we want to use it, we can thus caluclate it as: d = q2 * inverse(q1)
        Quaternion relativeDiff = receiver.transform.rotation * Quaternion.Inverse(transform.rotation);
        relativeDiff *= Quaternion.Euler(0, 180, 0);
        
        Vector3 positionOffset = currentlyOverlappingObject.transform.position - transform.position;
        positionOffset = relativeDiff * positionOffset;

        // rotate
        currentlyOverlappingObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().Rotate(relativeDiff);

        // position
        currentlyOverlappingObject.transform.position = receiver.transform.position + positionOffset;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<Portable>() != null)
        {
            currentlyOverlappingObject = other.GetComponentInParent<Portable>();
        } else if (other.GetComponent<Portable>() != null)
        {
            currentlyOverlappingObject = other.GetComponent<Portable>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<Portable>() != null)
        {
            currentlyOverlappingObject = null;
        }
    }
}
