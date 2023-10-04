using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Bullet))]
public class bulletEditor : Editor
{
    
    
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Pause"))
        {
            // ‘target’ is the magic variable that editors use to link back to the original component. It’s in the BASE CLASS, so you have to ‘cast’ to get access to YOUR functions.
            Bullet bullet;
            bullet = target as Bullet;
            if(bullet != null)
            {
                bullet.Pause();
            }
        }
        
        if (GUILayout.Button("uNPAUSE"))
        {
            // ‘target’ is the magic variable that editors use to link back to the original component. It’s in the BASE CLASS, so you have to ‘cast’ to get access to YOUR functions.
            Bullet bullet;
            bullet = target as Bullet;
            if(bullet != null)
            {
                bullet.UnPause();
            }
        }
    }
    

}
