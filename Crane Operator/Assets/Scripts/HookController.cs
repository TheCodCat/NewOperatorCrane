using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookController : MonoBehaviour
{
    [SerializeField] private CraneController controller;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private ConfigurableJoint joint;

    [SerializeField] private bool debug;

    
    public Cargo collisionGO;


    private void Update()
    {

        if (collisionGO is not null)
        {
            if (controller.bumper)
                Debug.Log("Click");
            if (controller.bumper && joint.connectedBody is null && collisionGO.GetComponentInParent<Cargo>().canGrab)
            {
                Debug.Log("Connected");
                Connetct(collisionGO);
            }

            if (!controller.bumper && joint.connectedBody is not null)
            {
                Debug.Log("Disconnect");
                Disconnect();
            }
        }

        if (debug && collisionGO != null)
        {
            if (Input.GetKeyDown(KeyCode.E) && joint.connectedBody is null && collisionGO.TryGetComponent(out Cargo cargo))
            {
                Connetct(cargo);
            }
            else if (Input.GetKeyDown(KeyCode.E) && joint.connectedBody is not null)
            {
                Disconnect();
            }
        }
    }

    private void Connetct(Cargo objectToConnetct)
    {
        Debug.Log("Connetct");
        objectToConnetct.isGrabbing = true;
        joint.connectedBody = objectToConnetct.GetRigidbody();
        joint.connectedAnchor = collisionGO.grabPoint.localPosition;
    }

    private void Disconnect()
    {
		joint.connectedBody.GetComponent<Cargo>().isGrabbing = false;
        joint.connectedBody = null;
        collisionGO = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "grabble")
        {
            Debug.Log("enter grabble");

            if(other.TryGetComponent(out GrapTrigger cargo))
                collisionGO = cargo.myCargo;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "grabble")
        {
            Debug.Log("exit grabble");
            collisionGO = null;
        }
    }
}
