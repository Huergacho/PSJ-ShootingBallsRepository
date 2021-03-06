using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Animator))]
public class AnimationManager : MonoBehaviour 
{
   public enum State
    {
        idle, run
    }
    private  State currentState;
    private Animator animator;
    private void Start()
    {
       animator = gameObject.GetComponent<Animator>();
    }
    private void Update()
    {
        SwitchAnimations();
    }
    void SwitchAnimations()
    {
        switch (currentState)
        {
            case State.idle:
                animator.SetFloat("Speed", 0);
                break;
            case State.run:
                animator.SetFloat("Speed", 1);
                break;
                

        }
    }
    public void ChangeState(State state)
    {
        currentState = state;
    }
}
