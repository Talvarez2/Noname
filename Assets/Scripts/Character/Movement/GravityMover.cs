using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GravityMover : MonoBehaviour
{ 
    
    public float gravity = 10;

    private MovementManager manager;
    private Vector3[] moveInfo = {new Vector3(), new Vector3(), new Vector3()};
    private Vector3 staticMovement = new Vector3();
    private Vector3 dynamicMovement = new Vector3();
    private float fallVelocity;

    IDictionary<string, Vector3[]> movement;
    CharacterController player;

    void Start()
    {
        manager = GetComponent<MovementManager>(); 
        player = manager.player;
        movement = manager.Vector3Stack;
        movement.Add("GravityMover",moveInfo);
    }
    void Update(){
        staticMovement = new Vector3();
        dynamicMovement = new Vector3();

        if (player.isGrounded) staticMovement.y = -2f;
        else  dynamicMovement.y =  -gravity;

        moveInfo[0] = staticMovement;
        moveInfo[1] = dynamicMovement;
        movement["GravityMover"] = moveInfo;
    }
    // void OnGUI(){
 
    //     // GUI.Label(new Rect(50,20,200,100),"Y pos = " + player.transform.position.y.ToString("0.00"));
    //     GUI.Label(new Rect(50,30,200,100),"Y vel = " + fallVelocity.ToString("0.00"));
    //     GUI.Label(new Rect(50,40,200,100),"Grounded = " + player.isGrounded.ToString());
        
    // }
    
}