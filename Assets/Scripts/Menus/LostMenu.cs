using UnityEngine;

/// <summary>
/// Death screen menu allowing the player to continue from the last checkpoint or retry from the start.
/// </summary>
public class LostMenu : MonoBehaviour
{
    public GameObject lostMenuUI;
    public GameObject lostMenuCamera;
    public GameObject lostMenuEventSystem;

    private GameObject _levelExtras;

    private void SetActiveMenuItems(bool value)
    {
        lostMenuUI.SetActive(value);
        lostMenuCamera.SetActive(value);
        lostMenuEventSystem.SetActive(value);
    }

    /// <summary>
    /// Shows the death menu and pauses the game.
    /// </summary>
    public void Lost()
    {
        SetActiveMenuItems(true);
        _levelExtras = GameObject.FindWithTag("LevelExtras");
        _levelExtras.GetComponent<LevelTimeScale>().StopLevel();
    }

    /// <summary>
    /// Respawns players at the last confirmed checkpoint and resumes the game.
    /// </summary>
    public void Continue()
    {
        _levelExtras.GetComponent<SpawnSystem>().SendPlayersToLastSpawnsPositions();
        _levelExtras.GetComponent<LevelTimeScale>().StartLevel();
        SetActiveMenuItems(false);
    }

    /// <summary>
    /// Respawns players at the initial start positions and resumes the game.
    /// </summary>
    public void Retry()
    {
        _levelExtras.GetComponent<SpawnSystem>().SendPlayersToInitialSpawnsPositions();
        _levelExtras.GetComponent<LevelTimeScale>().StartLevel();
        SetActiveMenuItems(false);
    }
}
