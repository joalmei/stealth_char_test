using UnityEngine;

public class InputManager : MonoBehaviour
{
    // ------------------------------ PUBLIC ATTRIBUTES ---------------------------- //
#if UNITY_EDITOR
    public bool                 m_useKeyboard               = false;
#endif

    // ------------------------------ PRIVATE ATTRIBUTES ---------------------------- //
    private static InputManager m_manager                   = null;

    private const string        GAMEPAD_LEFT_HORIZONTAL     = "Horizontal";
    private const string        GAMEPAD_LEFT_VERTICAL       = "Vertical";
    private const string        GAMEPAD_RIGHT_HORIZONTAL    = "Camera X";
    private const string        GAMEPAD_RIGHT_VERTICAL      = "Camera Y";
    private const string        GAMEPAD_LEFT_TRIGGER        = "Trigger Left";
    private const string        GAMEPAD_RIGHT_TRIGGER       = "Trigger Right";

    private const string        KEYBOARD_LEFT_SHIFT         = "Fire2";
    private const string        KEYBOARD_MOUSE_X            = "Mouse X";
    private const string        KEYBOARD_MOUSE_Y            = "Mouse Y";

    private const float         TRIGGER_MIN_FOR_TRUE        = 0.5f;

    // ============================================================================== //
    // PUBLIC MEMBERS
    // ============================================================================== //
    public void Awake ()
    {
        Debug.Assert(m_manager == null, this.gameObject.name + " - InputManager : input manager must be unique!");

        m_manager = this;
	}

    // ============================================================================== //
    public static float GetAxisHorizontal ()
    {
        return Input.GetAxis(GAMEPAD_LEFT_HORIZONTAL);
    }

    // ============================================================================== //
    public static float GetAxisVertical()
    {
        return Input.GetAxis(GAMEPAD_LEFT_VERTICAL);
    }

    // ============================================================================== //
    public static float GetCameraX()
    {
#if UNITY_EDITOR
        if (m_manager.m_useKeyboard)
        {
            return Input.GetAxis(KEYBOARD_MOUSE_X);
        }
#endif

        return Input.GetAxis(GAMEPAD_RIGHT_HORIZONTAL);
    }

    // ============================================================================== //
    public static float GetCameraY()
    {
#if UNITY_EDITOR
        if (m_manager.m_useKeyboard)
        {
            return Input.GetAxis(KEYBOARD_MOUSE_Y);
        }
#endif

        return Input.GetAxis(GAMEPAD_RIGHT_VERTICAL);
    }

    // ============================================================================== //
    public static bool GetButtonSneak()
    {
#if UNITY_EDITOR
        if (m_manager.m_useKeyboard)
        {
            return Input.GetButton(KEYBOARD_LEFT_SHIFT);
        }
#endif

        return Input.GetAxis(GAMEPAD_LEFT_TRIGGER) > TRIGGER_MIN_FOR_TRUE;
    }
}
