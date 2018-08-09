using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // ------------------------------ PUBLIC ATTRIBUTES ----------------------------- //
    [Header("Camera Position")]
    public float        m_distanceToPlayer      = 3;
    [Range(0,90)]
    public float        m_initialAngleToPlayer  = 30;

    [Header("Camera Settings")]
    public bool         m_invertY               = false;
    public float        m_sensibilityX          = 200;
    public float        m_sensibilityY          = 200;

    private const float MAX_Y_ANGLE             = 80;
    private const float MIN_Y_ANGLE             = 10;

    // ============================================================================== //
    // PUBLIC MEMBERS
    // ============================================================================== //
    void Start ()
    {
        this.transform.eulerAngles  = new Vector3(m_initialAngleToPlayer, 0, 0);
        this.transform.position     = Player.PlayerNode.m_centerPoint.position - this.transform.forward * m_distanceToPlayer;
	}

    // Update is called once per frame
    void Update()
    {
        this.transform.position     = Player.PlayerNode.m_centerPoint.position - this.transform.forward * m_distanceToPlayer;

        Vector2 rotateAround;
        //rotateAround.x            = Input.GetAxis("Mouse X");
        //rotateAround.y            = Input.GetAxis("Mouse Y");

        rotateAround.x              = InputManager.GetCameraX() * Time.deltaTime * m_sensibilityX;
        rotateAround.y              = InputManager.GetCameraY() * Time.deltaTime * m_sensibilityY;

        float camAngle              = Vector3.Angle(this.transform.forward, Player.PlayerNode.m_centerPoint.up) - 90;
        rotateAround.y              = Mathf.Clamp(m_invertY ? rotateAround.y : -rotateAround.y, MIN_Y_ANGLE - camAngle, MAX_Y_ANGLE - camAngle);


        this.transform.RotateAround(Player.PlayerNode.m_centerPoint.position, Vector3.up, rotateAround.x);
        this.transform.RotateAround(Player.PlayerNode.m_centerPoint.position, this.transform.right, rotateAround.y);
    }
}
