using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerController : ShootingActor
{
    [SerializeField] private float jumpForceImpulse;
    [SerializeField] private LayerMask groundLayer;
    public static event Action<int> ammoQuantity;
    private bool canMove;
    private bool canCheck;
    private void Awake()
    {
        
    }
    public override void Start()
    {
        base.Start();
        GameManager.instance.mainCharacter = this;
        LevelGeneration.spawnPoint += Spawn;
    }
    protected override void Update()
    {

        base.Update();
        MoveToMousePosition();
        ShowActualAmmo();

        if (canMove == true)
        {
            animationManager?.ChangeState(AnimationManager.State.run);
        }
        else
        {
            animationManager?.ChangeState(AnimationManager.State.idle);
        }
    }
    void MoveToMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            var target = hitInfo.point;
            target.y = transform.position.y;
            var distance = Vector3.Distance(transform.position, hitInfo.point);
            if(distance >= 1f)
            transform.LookAt(target);
        }
    }
    public void Move(Vector3 direction)
    {
        if (!isRunning)
        {
            rb.velocity = new Vector3(direction.x * speed, rb.velocity.y,direction.z * speed);
        }
        else
        {
            rb.velocity = new Vector3(direction.x * actorStats.RunSpeed, rb.velocity.y, direction.z * actorStats.RunSpeed) ;
        }
        if(direction == Vector3.zero)
        {
            rb.velocity = new Vector3(0,rb.velocity.y,0);
        }
    }
    public void MakeJump()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit,  2f ,groundLayer))
        {
            rb.AddForce(Vector3.up * jumpForceImpulse, ForceMode.Impulse);
        }
    }
    public override void Shoot()
    {
        equipedGun?.Shoot();
       // animationManager.ChangeState(AnimationManager.State.shoot);
    }
    public void ShowActualAmmo()
    {
        ammoQuantity?.Invoke(equipedGun.BulletsAmount);

    }
    public void isMoving(bool isMoving)
    {
        canMove = isMoving;
    }
    private void Spawn(Vector3 worldPos)
    {
        transform.position = worldPos;
    }
}
