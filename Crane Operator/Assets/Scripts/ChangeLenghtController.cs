using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CraneController))]
public class ChangeLenghtController : MonoBehaviour
{
    [SerializeField] private Rigidbody objectMove;
    [SerializeField] private float moveSpeed = 1.5f; // �������� �������� standart = 1.5
    [SerializeField] private Transform endPostion;
    [SerializeField] private Transform startPosition;

    private CraneController craneController; // ����������
    private float moveDirection;

    public void SetLenght(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>().y;
    }
    void Update()
    {
        //MoveDirection < 0 - �������� � �����
        //MoveDirection > 0 - �������� �����
        

        if (moveDirection != 0)
        {
            if (moveDirection > 0)
            {
                objectMove.velocity = objectMove.transform.up * -moveDirection * moveSpeed;

            }
            else if (moveDirection < 0)
            {
                objectMove.velocity = objectMove.transform.up * -moveDirection * moveSpeed;
            }
        }
        else
        {
            objectMove.velocity = new(0, 0, 0);
        }
    }

}
