using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private Color blue = Color.blue;
    private Color red = Color.red;
    private Color green = Color.green;
    private Light _light;

    void Start() 
    {
        _light = gameObject.GetComponentInChildren<Light>();
    } 

    public void ChangeColor(string color) 
    {
        
        if (color == "red")
        {
            _light.color = red;
        } else if (color == "blue")
        {
            _light.color = blue;
        } else if (color == "green")
        {
            _light.color = green;
        }
    }

    public string GetColor()
    {
        Color actualColor = _light.color;

        if (actualColor.Equals(red))
        {
            return "red";
        }
        if (actualColor.Equals(blue))
        {
            return "blue";
        }
        if (actualColor.Equals(green))
        {
            return "green";
        }
        return null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        float radius = GetComponent<SphereCollider>().radius;
        Gizmos.DrawSphere(transform.position, radius);
    }

}
