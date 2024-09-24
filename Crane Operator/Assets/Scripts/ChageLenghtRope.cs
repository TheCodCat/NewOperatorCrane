using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CraneController))]
public class ChageLenghtRope : MonoBehaviour
{
    [SerializeField] private RopeControllerSimple controller;
    [SerializeField] private float speed;

    private CraneController craneController;
    private float _grip;


    private void Start()
    {
        craneController = GetComponent<CraneController>();
    }
    public void SetGrip(InputAction.CallbackContext context)
    {
        _grip = context.ReadValue<Vector2>().y;
    }
    private void Update()
    {
        if (_grip != 0)
            controller.ChangeLenght(speed, (int)_grip);
    }
}
