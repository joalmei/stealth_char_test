using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MyStateMachineBhv : StateMachineBehaviour
{
    // -------------------------------- PUBLIC ENUMS -------------------------------- //
    public enum eAction
    {
        OnEnter,
        OnExit
    };

    // ------------------------------ PUBLIC ATTRIBUTES ----------------------------- //
    public eAction m_action;


    // ============================================================================== //
    // PUBLIC MEMBERS
    // ============================================================================== //

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (m_action == eAction.OnEnter)
        {
            ActivateBhv(animator, stateInfo, layerIndex);
        }
    }


    // TODO : OnAnimEnd and OnAnimRatio
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    if (!stateInfo.loop)
    //    {
    //    }
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (m_action == eAction.OnExit)
        {
            ActivateBhv(animator, stateInfo, layerIndex);
        }
    }

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}


    // ============================================================================== //
    virtual public void OnEditorUpdate()
    {
    }

    // ============================================================================== //
    // PROTECTED MEMBERS
    // ============================================================================== //
    abstract protected void ActivateBhv(Animator animator, AnimatorStateInfo stateInfo, int layerIndex);
    
}
