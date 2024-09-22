using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class CraneController : MonoBehaviour
{
    [SerializeField] private Transform Joystick;
    [SerializeField] private float joyMove = 10f;

    [SerializeField] private Material standartButton_material;
    [SerializeField] private Material selectButton_material;

    [SerializeField] private Renderer gripBtn;
    [SerializeField] private Renderer bumperBtn;

        /*if (interactable.attachedToHand)
        {
            hand = interactable.attachedToHand.handType;
            Joystick.localPosition = new Vector3(movement.y, 0,-movement.x) * joyMove;
            bumper = bumperAction[hand].state;

            if (bumper)
                bumperBtn.material = selectButton_material;
            else
                bumperBtn.material = standartButton_material;

            if (grip != 0)
                gripBtn.material = selectButton_material;
            else
                gripBtn.material = standartButton_material;
        }
        else
        {
            movement = Vector2.zero;
            grip = 0f;
            bumper = false;
            gripBtn.material = standartButton_material;
            bumperBtn.material = standartButton_material;
            Joystick.localPosition = movement * joyMove;
        }   */ 
}