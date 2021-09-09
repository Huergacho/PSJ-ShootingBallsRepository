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
        if(characterController == null)
        characterController = GameManager.instance.mainCharacter;
        if (Input.GetKey(KeyCode.Mouse0))
        {
            characterController.Shoot();
        }
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        Vector3 moveDirection = new Vector3(moveX, 0, moveZ);
        if(moveDirection == Vector3.zero)
        {
            characterController.isMoving(false);
        }
        else
        {
            characterController.isMoving(true);
        }
        characterController.Move(moveDirection);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            characterController.MakeJump();
        }
    }
}
