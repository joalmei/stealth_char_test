using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterCamera : MonoBehaviour
{
    // ------------------------------ PUBLIC ATTRIBUTES ----------------------------- //
    public static RegisterCamera CameraNode { get; protected set; }


    // ============================================================================== //
    // PUBLIC MEMBERS
    // ============================================================================== //
    public void Start ()
    {
        Debug.Assert(CameraNode == null, this.gameObject.name + " - CameraNode : RegisterCamera must be unique");

        CameraNode = this;
	}
}
