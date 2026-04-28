using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Detects when both players are standing on the exit door and triggers the win menu.
/// </summary>
public class WinSystem : MonoBehaviour
{
    private bool[] _playerOnExitDoor = { false, false };
    private GameObject _winMenu;

    private void Start()
    {
        FindWinMenuGameObject();
    }

    private void FindWinMenuGameObject()
    {
        Scene scene = SceneManager.GetSceneByName("YouWin");
        foreach (GameObject rootObject in scene.GetRootGameObjects())
        {
            if (rootObject.name == "YouWinMenu")
            {
                _winMenu = rootObject;
                return;
            }
        }
    }

    /// <summary>
    /// Toggles a player's presence on the exit door and checks if both players are there.
    /// </summary>
    public void UpdatePlayerOnExitDoor(int playerNum)
    {
        _playerOnExitDoor[playerNum - 1] = !_playerOnExitDoor[playerNum - 1];

        if (_playerOnExitDoor[0] && _playerOnExitDoor[1])
        {
            _winMenu.GetComponent<WinMenu>().Win();
        }
    }
}
