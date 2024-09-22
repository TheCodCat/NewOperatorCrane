using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CraneController))]
public class RotationController : MonoBehaviour
{
    [SerializeField] Transform objectRotate; // Объект который будем вращать
    [SerializeField] Transform axisRotate; // Точка во круг которой будет вращение
    [SerializeField] float rotationSpeed = 1; //Скорость вращения
    float rotateDirection;

	private CraneController craneController; // контроллер


    // Start is called before the first frame update
    private void Awake()
    {
        craneController = GetComponent<CraneController>();
    }
    public void SetMovoment(InputAction.CallbackContext context)
    {
        rotateDirection = context.ReadValue<Vector2>().x;

    }
    private void Update()
    {
        //objectRotate.RotateAround(axisRotate.position,new Vector3(0,rotateDirection,0), rotationSpeed * rotateDirection);
        if (rotateDirection > 0)
        {
            objectRotate.RotateAround(axisRotate.position, new Vector3(0, rotateDirection, 0), rotationSpeed * rotateDirection);
        }else {
            objectRotate.RotateAround(axisRotate.position, new Vector3(0, rotateDirection * -1, 0), rotationSpeed * rotateDirection);
        }

        //player.Rotate(new Vector3(0, rotateDirection * rotationSpeed, 0));
    }
}
