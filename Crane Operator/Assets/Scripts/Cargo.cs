using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cargo : MonoBehaviour
{
    [SerializeField] public Transform grabPoint;
    [SerializeField] public bool isGrabbing;
    [SerializeField] public bool canGrab = true;
    [SerializeField] private Rigidbody _rb;

    public Rigidbody GetRigidbody()
    {
        return _rb;
    }
}
