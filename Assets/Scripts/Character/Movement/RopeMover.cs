using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeMover : MonoBehaviour
{
    public bool show = false;
    public CharacterController otherPlayer;
    public int maxDist = 30;

    private MovementManager manager;
    private Vector3[] moveInfo = {new Vector3(), new Vector3(), new Vector3()};
    private float dist, angle, dist_delta;
    private Vector3 normalizedVector, projection;

    CharacterController player;
    IDictionary<string, Vector3[]> movement;


    void Start()
    {
        manager = GetComponent<MovementManager>();
        player = manager.player;
        movement = manager.Vector3Stack;
        movement.Add("RopeMover", moveInfo);
    }

    public Vector3 dotFunc(Vector3 potentialMovement){
        dist = Vector3.Distance(player.transform.position, otherPlayer.transform.position);
        if (dist>maxDist){
            // Angle from PLAYER to OTHER PLAYER
            angle = Vector3.SignedAngle(
                        new Vector3(1, 0, 0),
                        otherPlayer.transform.position -  player.transform.position,
                        new Vector3(0,0,1)
                        );

            normalizedVector = new Vector3(
                        Mathf.Cos(angle * 2 * Mathf.PI / 360),
                        Mathf.Sin(angle * 2 * Mathf.PI / 360), 0
                        );
            return normalizedVector*(dist-maxDist)*100;
        }
        else return Vector3.zero;
        }


    public Vector3 ropeFunction(Vector3 potentialMovement){
        dist = Vector3.Distance(player.transform.position, otherPlayer.transform.position);
        if (dist>maxDist){
            // Angle from OTHER PLAYER to PLAYER
            angle = Vector3.SignedAngle(
                        new Vector3(1, 0, 0),
                        player.transform.position - otherPlayer.transform.position,
                        new Vector3(0,0,1));
                    
            normalizedVector = new Vector3(
                        Mathf.Cos(angle * 2 * Mathf.PI / 360),
                        Mathf.Sin(angle * 2 * Mathf.PI / 360), 0);
            if (Vector3.Dot(potentialMovement,normalizedVector)>0) {
                projection = Vector3.Project(potentialMovement,normalizedVector)/2;
            }
            else projection = new Vector3(0,0,0);
        }
        else projection = new Vector3(0,0,0);

        return projection;
        }

    // void Update()
    // {

    // }
    void OnGUI()
    {
        if (show)
        {
            GUI.Label(new Rect(50, 80, 200, 100), "Angle = " + angle.ToString());
        }
    }
}
