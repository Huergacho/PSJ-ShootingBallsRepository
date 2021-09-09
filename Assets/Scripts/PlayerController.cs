using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerController : ShootingActor
{
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayer;
    public static event Action<int> ammoQuantity;
    private bool canMove;
    private void Awake()
    {
        
    }
    public override void Start()
    {
        base.Start();
        GameManager.instance.mainCharacter = this;
    }
    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        MoveToMousePosition();
        ShowActualAmmo();
        if (canMove == true)
        {
            animationManager.ChangeState(AnimationManager.State.run);
        }
        else
        {
            animationManager.ChangeState(AnimationManager.State.idle);
        }
    }
    void MoveToMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            var target = hitInfo.point;
            target.y = transform.position.y;
            transform.LookAt(target);
        }
    }
    public void Move(Vector3 direction)
    {
        transform.position += direction * speed * Time.deltaTime;
    }
    public void MakeJump()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit,  1f ,groundLayer))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Force);
        }
    }
    public override void Shoot()
    {
        equipedGun?.Shoot();
        animationManager.ChangeState(AnimationManager.State.shoot);
    }
    public void ShowActualAmmo()
    {
        ammoQuantity.Invoke(equipedGun.BulletsAmount);

    }
    public void isMoving(bool isMoving)
    {
        canMove = isMoving;
    }
}
