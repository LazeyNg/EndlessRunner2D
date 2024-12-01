#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [MenuItem("Scenes/Loading #1")]
    public static void OpenLoading()
    {
        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
        {
            EditorSceneManager.OpenScene("Assets/_Game/Scenes/Loading.unity");
        }
    }
    [MenuItem("Scenes/Home #2")]
    public static void OpenHome()
    {
        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
        {
            EditorSceneManager.OpenScene("Assets/_Game/Scenes/Home.unity");
        }
    }

    [MenuItem("Scenes/Game #3")]
    public static void OpenGame()
    {
        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
        {
            //EditorSceneManager.OpenScene("Assets/_Game/Scenes/Home.unity");
            EditorSceneManager.OpenScene("Assets/_Game/Scenes/Game.unity");
        }
    }
}
#endif