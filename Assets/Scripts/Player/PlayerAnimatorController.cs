using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : CharacterAnimatorController
{
    // ----------------------------- PROTECTED ATTRIBUTES --------------------------- //
    // booleans
    protected const string  IS_RUNNING      = "IsRunning";
    protected const string  IS_SNEAKING     = "IsSneaking";

    // triggers
    protected const string  ON_TURN         = "OnTurn";

    // ============================================================================== //
    // PUBLIC MEMBERS
    // ============================================================================== //
    override public void StartIdle()
    {
        m_animator.SetBool(IS_SNEAKING, false);
        m_animator.SetBool(IS_RUNNING, false);
    }

    // ============================================================================== //
    override public void StartRunning ()
    {
        m_animator.SetBool(IS_SNEAKING, false);
        m_animator.SetBool(IS_RUNNING, true);
    }
    
    // ============================================================================== //
    override public void StartSneakIdle()
    {
        m_animator.SetBool(IS_SNEAKING, true);
        m_animator.SetBool(IS_RUNNING, false);
    }

    // ============================================================================== //
    override public void StartSneakWalk()
    {
        m_animator.SetBool(IS_SNEAKING, true);
        m_animator.SetBool(IS_RUNNING, true);
    }

    // ============================================================================== //
    // PROTECTED MEMBERS
    // ============================================================================== //
    protected override void StartTurningLocal()
    {
        m_animator.SetTrigger(ON_TURN);
    }
}
