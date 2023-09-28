using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(Death))]
public class DeathEditor : Editor
{
    
    
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("DIE DIE DIE"))
            {
                // ‘target’ is the magic variable that editors use to link back to the original component. It’s in the BASE CLASS, so you have to ‘cast’ to get access to YOUR functions.
                Death death;
                death = target as Death;
                if(death != null)
                {
                    death.KillMe();
                }
            }
        }
    

}
