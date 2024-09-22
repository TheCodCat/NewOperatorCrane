using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Valve.VR;

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
        int direction = 0;

            if (_grip > 0)
                direction = 1;
            else if (_grip < 0)
                direction = -1;
            else
                direction = 0;


        if (direction == 1)
        {
            controller.ChangeLenght(speed, direction);
        }
            
        else if (direction == -1)
        {
            controller.ChangeLenght(speed, direction);
        }
    }
}
