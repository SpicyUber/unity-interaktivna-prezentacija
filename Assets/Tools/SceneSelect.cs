using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class SceneShortcutWindow : EditorWindow
{


    [InitializeOnLoad]
    public static class SceneShortcutAutoOpen
    {
        static SceneShortcutAutoOpen()
        {
            EditorApplication.delayCall += OpenWindow;
        }

        private static void OpenWindow()
        {
             
            if (!EditorWindow.HasOpenInstances<SceneShortcutWindow>())
            {
                SceneShortcutWindow.ShowWindow();
            }
        }
    }

    [MenuItem("Tools/Scene Shortcuts")]
    public static void ShowWindow()
    {
        GetWindow<SceneShortcutWindow>("Scene Shortcuts");
    }

    private void OnGUI()
    {
        GUILayout.Label("Scene Shortcuts", EditorStyles.boldLabel);

       
        var scenes = EditorBuildSettings.scenes;

        foreach (var scene in scenes)
        {
            string sceneName = System.IO.Path.GetFileNameWithoutExtension(scene.path);

            
            if (GUILayout.Button(sceneName))
            {
                
                if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                {
                    EditorSceneManager.OpenScene(scene.path);
                }
            }
        }
    }
}