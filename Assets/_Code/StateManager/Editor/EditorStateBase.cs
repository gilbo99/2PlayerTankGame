using System.Collections;
using System.Collections.Generic;
using Andrew;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(StateBase), true)]
public class EditorStateBase : Editor
{
    
    
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Change State"))
        {
            (target as StateBase)?.stateBase.stageManager.SwitchState(target as StateBase);
        }
        
        
    }
    

}