using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class CraneController : MonoBehaviour
{
	[SerializeField] private float joysticPosition;
    [SerializeField] private Transform Joystick;
	[SerializeField] private TypeJoystic typeJoystic;

	[SerializeField] private Transform stickPositionRight;
	[SerializeField] private Transform stickPositionLeft;
	[SerializeField] private Transform stickPositionCenter;

	[SerializeField] private Material standartButton_material;
    [SerializeField] private Material selectButton_material;

    [SerializeField] private Renderer gripBtn;
    [SerializeField] private Renderer bumperBtn;

    private bool _bumper;
	private float _grip;


    public void SetBumper(InputAction.CallbackContext context)
    {
        if (context.performed && HookController.instance.GetBumper())
        {
            _bumper = !_bumper;

		    if (_bumper)
			    bumperBtn.material = selectButton_material;
		    else
			    bumperBtn.material = standartButton_material;
        }
	}
	public void SetGrip(InputAction.CallbackContext context)
	{
		_grip = context.ReadValue<Vector2>().y;

		if (_grip != 0)
			gripBtn.material = selectButton_material;
		else
			gripBtn.material = standartButton_material;
	}

	public void SetPositionJoystic(InputAction.CallbackContext context)
	{
		switch (typeJoystic)
		{
			case TypeJoystic.vertical:
				joysticPosition = context.ReadValue<Vector2>().y;
				break;
			case TypeJoystic.horizontal:
				joysticPosition = context.ReadValue<Vector2>().x;
				break;
		}
		if (joysticPosition > 0) Joystick.position = stickPositionRight.position;
		else if (joysticPosition < 0) Joystick.position = stickPositionLeft.position;
		else Joystick.position = stickPositionCenter.position;
	}
	/*
		Joystick.localPosition = new Vector3(movement.y, 0,-movement.x) * joyMove;

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
public enum TypeJoystic
{
	vertical,horizontal
}