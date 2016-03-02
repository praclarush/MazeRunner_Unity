using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(MazeGenerator))]
public class MazeGeneratorInspector : Editor {
    
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        if (GUILayout.Button("Regenerate"))
        {
            MazeGenerator tileMap = (MazeGenerator)target;
            tileMap.GenerateMaze();
        }
    }
}
