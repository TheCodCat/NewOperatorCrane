using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HookController : MonoBehaviour
{
    public static HookController instance;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private ConfigurableJoint joint;
    
    public Cargo collisionGO;
    private bool bumper;

	private void Awake()
	{
        if (instance == null)
        {
            instance = this;     
        }
        else Destroy(instance.gameObject);
	}

	public void SetBumper(InputAction.CallbackContext context)
    {
        if (context.performed && collisionGO != null)
        {
			bumper = !bumper;
		}

        if (collisionGO is not null)
        {
            if (bumper)
                Debug.Log("Click");
            if (bumper && joint.connectedBody is null && collisionGO.GetComponentInParent<Cargo>().canGrab)
            {
                Debug.Log("Connected");
                Connetct(collisionGO);
            }

            if (!bumper && joint.connectedBody is not null)
            {
                Debug.Log("Disconnect");
                Disconnect();
            }
        }
    }
    public bool GetBumper()
    {
        return bumper;
    }
    private void Connetct(Cargo objectToConnetct)
    {
        Debug.Log("Connetct");
        objectToConnetct.isGrabbing = true;
        joint.connectedBody = objectToConnetct.GetRigidbody();
        objectToConnetct.grabPoint.position = joint.transform.position;
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
