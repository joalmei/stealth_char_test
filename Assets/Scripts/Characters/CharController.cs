using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharController : MonoBehaviour
{
    // -------------------------------- PUBLIC ENUMS -------------------------------- //
    public enum eState
    {
        Idle,
        //Walking,  TODO
        Running,
        //Stopping, TODO
        Turning,

        SneakIdle,
        SneakWalk,

        //WallIdle,
        //WallLeft,
        //WallRight
    }

    // ------------------------------ PUBLIC ATTRIBUTES ----------------------------- //
    public float                        m_runSpeed          = 0.1f;
    public float                        m_sneakSpeed        = 0.05f;
    public float                        m_turnSpeed         = 10;
    public float                        m_stopSpeed         = 5;
    public CharacterAnimatorController  m_animator;

    // ------------------------------ PRIVATE ATTRIBUTES ---------------------------- //
    protected eState                    m_state             = eState.Idle;
    protected float                     m_speed             = 0;

    protected const float               MIN_SPEED_TO_STOP   = 0.1f;
    protected const float               MIN_ANGLE_TO_TURN   = 150;

    protected const float               SPEED_ACCELERATION  = 2.5f;


    // ============================================================================== //
    // PUBLIC MEMBERS
    // ============================================================================== //
    public virtual void Start()
    {
        Debug.Assert(m_animator != null, this.gameObject.name + " : CharacterController - Missing PlayerAnimatorController");
        m_state = eState.Idle;
    }

    // ============================================================================== //
    public virtual void LateUpdate()
    {
        // get input
        Vector2 nextDirection   = GetInputDirection();
        bool    isSneaking      = GetInputSneak();

        m_speed                 = GetSpeed(nextDirection, isSneaking);


        // get next state
        eState nextState        = NextState(nextDirection, m_speed, isSneaking);

        // update actual state
        UpdateAnimator(nextState);
        UpdateTransform(nextDirection, m_speed, nextState);

        // go to next state
        m_state = nextState;
    }


    // ============================================================================== //
    // PROTECTED MEMBERS
    // ============================================================================== //
    protected abstract Vector2 GetInputDirection();

    // ============================================================================== //
    protected abstract bool GetInputSneak();

    // ============================================================================== //
    protected virtual float GetSpeed(Vector2 _inputDirection, bool _isSneaking)
    {
        if (_inputDirection == Vector2.zero)
        {
            float speed = Mathf.Lerp(m_speed, 0, m_stopSpeed * Time.deltaTime);

            return m_speed > MIN_SPEED_TO_STOP ? m_speed : 0;
        }
        else
        {
            return Mathf.Lerp(m_speed, _isSneaking ? m_sneakSpeed : m_runSpeed, SPEED_ACCELERATION * Time.deltaTime);
        }
    }

    // ============================================================================== //
    protected virtual void UpdateAnimator(eState _nextState)
    {
        if (_nextState == eState.Running)
        {
            StartRunning();
        }
        else if (_nextState == eState.Turning && m_state != eState.Turning)
        {
            StartTurning();
        }
        else if (_nextState == eState.SneakWalk)
        {
            StartSneakWalk();
        }
        else if (_nextState == eState.SneakIdle)
        {
            StartSneakIdle();
        }
        else
        {
            StartIdle();
        }
    }

    // ============================================================================== //
    protected virtual eState NextState(Vector2 _runDirection, float _speed, bool _isSneaking)
    {
        // while turning, wait for turn end
        if (m_state == eState.Turning)
        {
            if (m_animator.IsTurning())
            {
                return eState.Turning;
            }
            else
            {
                if (_runDirection == Vector2.zero)
                {
                    return eState.Idle;
                }
                else
                {
                    return eState.Running;
                }
            }
        }

        if (_runDirection != Vector2.zero)
        {
            if (_isSneaking)
            {
                return eState.SneakWalk;
            }
            else
            {
                Vector2 direction = new Vector2(this.transform.forward.x, this.transform.forward.z);
                if (Vector2.Angle(_runDirection, direction) < MIN_ANGLE_TO_TURN)
                {
                    return eState.Running;
                }
                else
                {
                    return eState.Turning;
                }
            }
        }
        else
        {
            if (_isSneaking)
            {
                return eState.SneakIdle;
            }
            else
            {
                return eState.Idle;
            }
        }
    }

    // ============================================================================== //
    protected virtual void StartIdle()
    {
        m_animator.StartIdle();
    }

    // ============================================================================== //
    protected virtual void StartRunning()
    {
        m_animator.StartRunning();
    }

    // ============================================================================== //
    protected virtual void StartTurning()
    {
        m_animator.StartTurning();
    }

    // ============================================================================== //
    protected virtual void StartSneakIdle()
    {
        m_animator.StartSneakIdle();
    }

    // ============================================================================== //
    protected virtual void StartSneakWalk()
    {
        m_animator.StartSneakWalk();
    }

    // ============================================================================== //
    protected virtual void UpdateTransform(Vector2 _direction, float _speed, eState _nextState)
    {
        if (m_state == eState.Turning && _nextState != eState.Turning)
        {
            this.transform.forward = -this.transform.forward;
        }
        else if (_nextState == eState.Running || _nextState == eState.SneakWalk)
        {
            this.transform.forward = Vector3.Lerp(this.transform.forward, (_direction.x * Vector3.right + _direction.y * Vector3.forward), m_turnSpeed * Time.deltaTime);
            this.transform.position += _speed * this.transform.forward;
        }
    }
}
