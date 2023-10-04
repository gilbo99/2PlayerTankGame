using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(ArenaManager))]
public class ArenaManagerEditor : Editor
{
    
    
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Setup"))
        {
            // ‘target’ is the magic variable that editors use to link back to the original component. It’s in the BASE CLASS, so you have to ‘cast’ to get access to YOUR functions.
            ArenaManager arenaManager;
            arenaManager = target as ArenaManager;
            if(arenaManager != null)
            {
                arenaManager.SetUp();
            }
        }
        
        if (GUILayout.Button("RestartLevel"))
        {
            // ‘target’ is the magic variable that editors use to link back to the original component. It’s in the BASE CLASS, so you have to ‘cast’ to get access to YOUR functions.
            ArenaManager arenaManager;
            arenaManager = target as ArenaManager;
            if(arenaManager != null)
            {
                arenaManager.RestartLevel();
            }
        }
        
        
    }
    

}
