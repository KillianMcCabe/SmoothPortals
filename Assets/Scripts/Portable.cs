using UnityEngine;

public class Portable : MonoBehaviour
{
    // we need to implement a sepcial case for FPSController
    private UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpsController;

    void Start()
    {
        fpsController = GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
    }

    public virtual void Teleport(Transform fromPortalTransform, Transform toPortalTransform)
    {
        // get relative difference between two rotations (i.e. the quaternion that would turn this rotation into that rotation)
        // so say we want quaternion d which we can use like so: d * q1 = q2
        // knowing how we want to use it, we can thus caluclate it as: d = q2 * inverse(q1)
        Quaternion relativeDiff = toPortalTransform.rotation * Quaternion.Inverse(fromPortalTransform.rotation);
        relativeDiff *= Quaternion.Euler(0, 180, 0); // we also need to rotate an extra 180 deg because one portal's render planes are facing opposite directions

        Vector3 positionOffset = transform.position - fromPortalTransform.position;
        positionOffset = relativeDiff * positionOffset;
        
        // position
        transform.position = toPortalTransform.position + positionOffset;

        // rotate
        if (fpsController != null)
        {
            fpsController.Rotate(relativeDiff);
        }
        else
        {
            gameObject.transform.rotation *= relativeDiff;
        }
        
    }
    
}
