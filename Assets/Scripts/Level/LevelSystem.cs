using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSystem : MonoBehaviour
{
    private int implementedLevels = 2;

    private void Start()
    {
        int c = SceneManager.sceneCount;
        for (int i = 0; i < c; i++)
        {
            Scene s = SceneManager.GetSceneAt(i);
            if (s.name.Contains("Level"))
            {
                Scene activeScene = SceneManager.GetActiveScene();
                if (s != activeScene)
                {
                    SceneManager.SetActiveScene(s);
                }
            }
        }
    }

    public int GetActualLevel()
    {
        Scene s = SceneManager.GetActiveScene();
        int actualLevel = Int32.Parse(s.name.Substring(s.name.Length - 1));
        return actualLevel;
    }

    public bool CheckNextLevel()
    {
        if (GetActualLevel() < implementedLevels)
        {
            return true;
        }

        return false;
    }

}
