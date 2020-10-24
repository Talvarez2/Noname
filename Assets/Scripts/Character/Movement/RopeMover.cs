using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeMover : MonoBehaviour
{
    public bool show = false;
    public CharacterController otherPlayer;
    public int maxDist = 20;

    private MovementManager manager;
    private Vector3 movePlayer;
    private float dist, angle;

    CharacterController player;
    IDictionary<string, Vector3> movement;
    
    
    void Start()
    {
        manager = GetComponent<MovementManager>(); 
        player = manager.player;
        movement = manager.SpVector3Stack;
        movement.Add("RopeMover",movePlayer);
    }
    
    void Update(){
        movePlayer = new Vector3(0,0,0);
        dist = Vector3.Distance(player.transform.position, otherPlayer.transform.position);
        angle = Vector3.Angle(new Vector3(1,0,0), otherPlayer.transform.position- player.transform.position);
        if (dist>maxDist){
            float x = Mathf.Cos(angle*2*Mathf.PI/360);
            float y = Mathf.Sin(angle*2*Mathf.PI/360);
            movePlayer = new Vector3(x,y,0)*(dist-maxDist);
        }
        movement["RopeMover"] = movePlayer;

    }
     void OnGUI(){
        if (show)
        {
            GUI.Label(new Rect(50,20,200,100),"Dist = " + dist.ToString("0.00"));
            GUI.Label(new Rect(50,30,200,100),"Angle = " + angle.ToString("0.00"));        
        }
    }
}
