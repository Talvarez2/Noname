using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles player death by activating the "You Lost" overlay menu.
/// </summary>
public class HandleDeath : MonoBehaviour
{
    private GameObject _lostMenu;

    private void Start()
    {
        FindLostMenuGameObject();
    }

    private void FindLostMenuGameObject()
    {
        Scene scene = SceneManager.GetSceneByName("YouLost");
        foreach (GameObject rootObject in scene.GetRootGameObjects())
        {
            if (rootObject.name == "YouLostMenu")
            {
                _lostMenu = rootObject;
                return;
            }
        }
    }

    /// <summary>
    /// Triggers the death sequence by showing the lost menu.
    /// </summary>
    public void Die()
    {
        _lostMenu.GetComponent<LostMenu>().Lost();
    }
}
