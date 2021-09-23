using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (PlayerController))]
public class PlayerInputs : MonoBehaviour
{
    private Actor character;
    [SerializeField]private PlayerController characterController;
    private void Start()
    {
    }
    private void Update()
    {
        AssingPlayer();
        Shoot();
        Movement(); 
    }
    private void Shoot()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            characterController.Shoot();
        }
    }
    private void Movement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        Vector3 moveDirection = new Vector3(moveX, 0, moveZ);
        Vector3 directionNormalized = moveDirection.normalized;
        if (moveDirection == Vector3.zero)
        {
            characterController.isMoving(false);
        }
        else
        {
            characterController.isMoving(true);
            characterController.Move(directionNormalized);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            characterController.CanSprint(true);
        }
        else
        {
            characterController.CanSprint(false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            characterController.MakeJump();
        }
    }
    private void AssingPlayer()
    {
        if (characterController == null)
            characterController = GameManager.instance.mainCharacter;
    }
}
