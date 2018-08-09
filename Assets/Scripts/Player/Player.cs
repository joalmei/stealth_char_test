using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // ------------------------------ PUBLIC ATTRIBUTES ----------------------------- //
    public static Player PlayerNode { get; private set; }
    public Transform     m_centerPoint;


    // ============================================================================== //
    // PUBLIC MEMBERS
    // ============================================================================== //
    public void Awake ()
    {
        Debug.Assert(PlayerNode == null,        this.gameObject.name + " - Player : Player must be UNIQUE!");
        Debug.Assert(m_centerPoint != null,     this.gameObject.name + " - Player : Missing Center Point");

        PlayerNode = this;
	}
}
