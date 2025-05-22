using System.Security.Policy;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    
    public static void LoadScene(string levelName)
    {
        if (SceneExists(levelName))
        {
            SceneManager.LoadScene(levelName);
        }
        else
        {
            Debug.LogWarning("Escena no encontrada, cargando menú.");
            SceneManager.LoadScene("Menu");
        }
    }

    private static bool SceneExists(string sceneName)
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        for (int i = 0; i < sceneCount; i++)
        {
            string path = SceneUtility.GetScenePathByBuildIndex(i);
            string sceneNameFromPath = System.IO.Path.GetFileNameWithoutExtension(path);
            if (sceneNameFromPath == sceneName)
            {
                return true;
            }
        }
        return false;
    }
}