using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BhvSendMessage : MyStateMachineBhv
{
    // -------------------------------- PUBLIC ENUMS -------------------------------- //
    public enum eParamType
    {
        Int,
        Float,
        Bool,
        String
    };

    // ------------------------------ PUBLIC ATTRIBUTES ----------------------------- //
    public string       m_message           = "";
    public bool         m_sendParameter     = false;
    
    [ConditionalHide("m_sendParameter", true)]
    public eParamType   m_paramType         = eParamType.Int;
    
    [ConditionalHide("m_showInt",       true)]
    public int          m_intParam          = 0;
    [ConditionalHide("m_showFloat",     true)]
    public float        m_floatParam        = 0.0f;
    [ConditionalHide("m_showBool",      true)]
    public bool         m_boolParam         = false;
    [ConditionalHide("m_showString",    true)]
    public string       m_stringParam       = "";

    // ------------------------------ PRIVATE ATTRIBUTES ---------------------------- //
    [HideInInspector]
    public bool        m_showInt           = false;
    [HideInInspector]
    public bool        m_showFloat         = false;
    [HideInInspector]
    public bool        m_showBool          = false;
    [HideInInspector]
    public bool        m_showString        = false;



    // ============================================================================== //
    // PUBLIC MEMBERS
    // ============================================================================== //
    protected override void ActivateBhv(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.SendMessage(m_message);
    }

    // ============================================================================== //
    public override void OnEditorUpdate()
    {
        base.OnEditorUpdate();

        m_showInt       = m_sendParameter && m_paramType == eParamType.Int;
        m_showFloat     = m_sendParameter && m_paramType == eParamType.Float;
        m_showBool      = m_sendParameter && m_paramType == eParamType.Bool;
        m_showString    = m_sendParameter && m_paramType == eParamType.String;
    }
}
