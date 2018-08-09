using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterAnimatorController : MonoBehaviour
{
    // ------------------------------------------------------------------------------ //
    public Animator m_animator  = null;

    // state attributes
    private bool    m_isTurning = false;

    // ============================================================================== //
    // PUBLIC VIRTUAL MEMBERS
    // ============================================================================== //
    public virtual void Awake()
    {
        if (m_animator == null)
        {
            m_animator = this.GetComponent<Animator>();
        }

        Debug.Assert(m_animator != null, this.gameObject.name + " : PlayerAnimatorController - Missing Animator");
    }

    // ============================================================================== //
    public virtual void StartTurning()
    {
        m_isTurning = true;
        StartTurningLocal();
    }

    // ============================================================================== //
    public virtual bool IsTurning()
    {
        return m_isTurning;
    }

    // ============================================================================== //
    public virtual void MSG_OnTurnExit()
    {
        m_isTurning = false;
    }

    // ============================================================================== //
    // PUBLIC ABSTRACT MEMBERS
    // ============================================================================== //
    public abstract void StartIdle();

    // ============================================================================== //
    public abstract void StartRunning();

    // ============================================================================== //
    public abstract void StartSneakIdle();

    // ============================================================================== //
    public abstract void StartSneakWalk();
    
    // ============================================================================== //
    // PROTECTED MEMBERS
    // ============================================================================== //
    protected abstract void StartTurningLocal();
}
