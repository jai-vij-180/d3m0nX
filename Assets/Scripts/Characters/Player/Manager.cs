using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour
{
    //This script controls all the animations related to the character JAC1000

    //wanna add a new state? 
    //declare it inside the enum
    //pass the state and its bool value from another class based on events.
    //be sure to add the AnimationEvent in the animation incase it will stop after some frames ( like jump,attack,transformations)

   

    public enum States
    {
        idle,
        walk,
        shoot,
        die,
        hit,
        run,
        jump
    }


    public Animator animator;


    

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void StateChanger(States newState, bool isPlaying)
    {
        animator.SetBool(newState.ToString(), isPlaying); //passing the bools 
    }

}
