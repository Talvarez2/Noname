using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandleDeath : MonoBehaviour
{
    private GameObject lostMenu;

    void Start()
    {
        LookForLostMenuGameObject();
    }

    private void LookForLostMenuGameObject()
    {
        Scene s = SceneManager.GetSceneByName("YouLost");
        GameObject[] gameObjects = s.GetRootGameObjects();
        foreach (var gameObject in gameObjects)
        {
            if (gameObject.name == "YouLostMenu")
            {
                lostMenu = gameObject;
            }
        }
    }

    public void Die()
    {
        lostMenu.GetComponent<LostMenu>().Lost();
    }

    public void Reset()
    {
        GetComponent<HealthAndDamage>().RestartLife();
        GetComponent<Spawn>().respawn();
    }

}
