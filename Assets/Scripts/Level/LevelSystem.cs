using System;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Detects the current level from the active scene name and checks whether a next level exists.
/// </summary>
public class LevelSystem : MonoBehaviour
{
    [SerializeField] private int implementedLevels = 1;

    private void Start()
    {
        int sceneCount = SceneManager.sceneCount;
        for (int i = 0; i < sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (scene.name.Contains("Level") && scene != SceneManager.GetActiveScene())
            {
                SceneManager.SetActiveScene(scene);
            }
        }
    }

    /// <summary>
    /// Returns the current level number parsed from the active scene name.
    /// </summary>
    public int GetActualLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        return Int32.Parse(scene.name.Substring(scene.name.Length - 1));
    }

    /// <summary>
    /// Returns true if there is a next level available.
    /// </summary>
    public bool CheckNextLevel()
    {
        return GetActualLevel() < implementedLevels;
    }
}
