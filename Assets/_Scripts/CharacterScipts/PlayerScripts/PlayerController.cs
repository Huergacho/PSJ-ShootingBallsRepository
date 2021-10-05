using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[RequireComponent(typeof (PlayerInputs))]
public class PlayerController : Actor
{
    [SerializeField] private float jumpForceImpulse;
    [SerializeField] private LayerMask groundLayer;
    public static event Action<float> lifeUpdate;
    private bool canMove;
    private bool canCheck;
    private Vector3 target;
    [SerializeField]private Transform lastSpawnPoint;
    private void Awake()
    {
        
    }
    protected override void Start()
    {
        base.Start();
        DontDestroyOnLoad(gameObject);
        GameManager.instance.mainCharacter = this;
        LevelGeneration.spawnPoint += SpawnInDungeon;
        lastSpawnPoint.position = transform.position;
    }
    protected override void Update()
    {

        base.Update();
        MoveToMousePosition();
        ShowActualLife();
        Debug.DrawRay(transform.position, Vector3.down * 1f, Color.red);
        if (canMove == true)
        {
            if (isRunning)
            {
                animationManager.ChangeState(AnimationManager.State.run);
            }
            else
            {
                animationManager.ChangeState(AnimationManager.State.walk);
            }
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
            target = hitInfo.point;
            target.y = transform.position.y;
            var distance = Vector3.Distance(transform.position, hitInfo.point);
            if (distance >= 1f)
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

        if (Physics.Raycast(new Vector3(transform.position.x,transform.position.y + 3,transform.position.z), Vector3.down, out hit,  3f ,groundLayer))
        {
            rb.AddForce(Vector3.up * jumpForceImpulse, ForceMode.Impulse);
        }
    }
    public void ShowActualLife()
    {
        lifeUpdate?.Invoke(currentLife);
    }
    public void isMoving(bool isMoving)
    {
        canMove = isMoving;
    }
    private void SpawnInDungeon(Vector3 worldPos)
    {
        transform.position = worldPos;
    }
    protected override void Respawn()
    {
        base.Respawn();
        transform.position = lastSpawnPoint.position;
    }



}
