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

        character  = GameManager.instance.mainCharacter;
        characterController = GetComponent<PlayerController>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            characterController.Shoot();
        }
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        Vector3 moveDirection = new Vector3(moveX, 0, moveZ);
        characterController.Move(moveDirection);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            characterController.MakeJump();
        }
    }
}
