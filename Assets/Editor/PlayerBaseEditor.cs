using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerBase))]
public class PlayerBaseEditor : Editor
{

    public PlayerBase script;
    public int limbid = 0;
    public void OnEnable()
    {
        script = target as PlayerBase;
    }


    public string[] GetLimbList()
    {
        List<string> limbNames = new List<string>();
        for(int i=0;i<LimbManager.limbDefinitions.Count;i++)
        {
            limbNames.Add(LimbManager.limbDefinitions[i].name);
        }
        return limbNames.ToArray();
    }
    public override void OnInspectorGUI()
    {
        if(LimbManager.instance == null)
        {
            EditorGUILayout.HelpBox("Limb Spawner available only when game is running",MessageType.Warning);
        }
        else
        {
            EditorGUILayout.BeginHorizontal();
            limbid = EditorGUILayout.Popup(limbid, GetLimbList());
            if (GUILayout.Button("Add Limb"))
            {
                script.RegisterLimb(LimbManager.limbDefinitions[limbid]);
            }
            EditorGUILayout.EndHorizontal();
            if (GUILayout.Button("Delet Limbs"))
            {
                script.UnregisterAllLimbs();
            }
        }
        
        DrawDefaultInspector();
    }
}
