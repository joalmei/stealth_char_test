using UnityEditor;

[CustomEditor(typeof(MyStateMachineBhv), true)]
public class MyStateMachineBhvEditor : Editor
{
    // ----------------------------- PROTECTED ATTRIBUTES --------------------------- //
    protected MyStateMachineBhv mySMBhv;

    // ============================================================================== //
    // PUBLIC MEMBERS
    // ============================================================================== //
    public void OnEnable()
    {
        mySMBhv = (MyStateMachineBhv) this.target;
    }

    // ============================================================================== //​
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        mySMBhv.OnEditorUpdate();
    }
}
