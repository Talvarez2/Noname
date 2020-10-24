using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GravityMover : MonoBehaviour
{ 
    
    public float gravity = 10;

    private MovementManager manager;
    private Vector3 movePlayer;
    private float fallVelocity;

    IDictionary<string, Vector3> movement;
    CharacterController player;

    void Start()
    {
        manager = GetComponent<MovementManager>(); 
        player = manager.player;
        movement = manager.Vector3Stack;
        movement.Add("GravityMover",movePlayer);
    }
    void Update(){
        if (player.isGrounded)  // if player is touching not touching the flor it accelerates downwards
        {
            fallVelocity = -2f;
            movePlayer.y = fallVelocity;
        }
        else
        {
            fallVelocity -= gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
        movement["GravityMover"] = movePlayer;
    }
    // void OnGUI(){
 
    //     // GUI.Label(new Rect(50,20,200,100),"Y pos = " + player.transform.position.y.ToString("0.00"));
    //     GUI.Label(new Rect(50,30,200,100),"Y vel = " + fallVelocity.ToString("0.00"));
    //     GUI.Label(new Rect(50,40,200,100),"Grounded = " + player.isGrounded.ToString());
        
    // }
    
}