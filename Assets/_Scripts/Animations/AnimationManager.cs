using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Animator))]
public class AnimationManager : MonoBehaviour 
{
   public enum State
    {
<<<<<<< HEAD:Assets/Scripts/Animations/AnimationManager.cs
        idle, run, walk,attack
=======
        idle, run, walk,attack,getHit
>>>>>>> develop:Assets/_Scripts/Animations/AnimationManager.cs
    }
    private  State currentState;
    private Animator animator;
    public bool attackState;
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
            case State.walk:
                animator.SetFloat("Speed", 0.5f);
                break;
            case State.run:
                animator.SetFloat("Speed", 1);
                break;
            case State.attack:
<<<<<<< HEAD:Assets/Scripts/Animations/AnimationManager.cs
                animator.SetTrigger("Attacking");
                print("Hace la Animacion de Ataque");
=======
                animator.SetTrigger("OnAttack");
                break;
            case State.getHit:
                animator.SetTrigger("OnHit");
>>>>>>> develop:Assets/_Scripts/Animations/AnimationManager.cs
                break;

        }
    }
    public void ChangeState(State state)
    {
        currentState = state;
    }
}
