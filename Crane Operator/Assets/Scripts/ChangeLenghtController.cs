using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CraneController))]
public class ChangeLenghtController : MonoBehaviour
{
    [SerializeField] private Rigidbody objectMove;
    [SerializeField] private float moveSpeed = 1.5f; // �������� �������� standart = 1.5
    [SerializeField] private Transform endPostion;
    [SerializeField] private Transform startPosition;

    private CraneController craneController; // ����������


    // Start is called before the first frame update
    void Start()
    {
        //startPosition = objectMove.transform;
        craneController = GetComponent<CraneController>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveDirection = craneController.movement.y;


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
