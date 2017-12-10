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


    void OnTriggerEnter(Collider other)
    {
        // This will break if two portable objects are passing through the same portal at the same time
        // TODO: Reimplement in Portable script
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
        else if (other.GetComponent<Portable>() != null)
        {
            currentlyOverlappingObject = null;
        }
    }
}
