using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace SkyHook.Editor
{
    [CustomEditor(typeof(SkyHookManager))]
    public class SkyHookEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            SkyHookManager manager = (SkyHookManager)target;
            
            GUI.enabled = false;
            EditorGUILayout.Toggle("Hook Started", manager.isHookActive);
            GUI.enabled = true;
            
            manager.requireFocus = EditorGUILayout.Toggle("Require Focus", manager.requireFocus);
            
            GUI.enabled = manager.requireFocus;
            SkyHookManager.isFocused = EditorGUILayout.Toggle("Focus", SkyHookManager.isFocused);
            GUI.enabled = true;

        }
    }
}
