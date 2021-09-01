using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (PlayerController))]
public class PlayerInputs : MonoBehaviour
{
    [SerializeField] private PlayerController character;
    private void Start()
    {
        character = GetComponent<PlayerController>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            character.Shoot();
        }
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        Vector3 moveDirection = new Vector3(moveX, 0, moveZ);
        character.Move(moveDirection);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            character.MakeJump();
        }
    }
}
