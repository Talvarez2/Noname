using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTimeScale : MonoBehaviour
{
    public void StopLevel()
    {
        Time.timeScale = 0f;
    }
    public void StartLevel()
    {
        Time.timeScale = 1f;
    }
}
