using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    public IDictionary<string, Vector3> Vector3Stack = new Dictionary<string, Vector3>();
    public IDictionary<string, Vector3> SpVector3Stack = new Dictionary<string, Vector3>();
    public CharacterController player;
    private Vector3 movePlayer = new Vector3(0,0,0);
    private Vector3 spMovePlayer = new Vector3(0,0,0);
    public Animator playerAnimatorController;

    private Renderer renderer;
    

    void Start(){
        player = GetComponentInParent<CharacterController>();
    }

    void Update(){
        movePlayer = new Vector3(0,0,0);
        spMovePlayer = new Vector3(0,0,0);
        foreach (KeyValuePair<string,Vector3> kvp in Vector3Stack){
            if (kvp.Key=="RopeMover"){
                player.Move(kvp.Value);        
            }
            else movePlayer +=kvp.Value;
        }
        
        foreach (KeyValuePair<string,Vector3> kvp in SpVector3Stack){
            Vector3 movementVector;
            if (kvp.Key=="RopeMover"){
                movementVector = kvp.Value;
                if (player.isGrounded)
                    movementVector.y = 0;
                spMovePlayer += movementVector;
            }
        }
        
        player.Move(movePlayer * Time.deltaTime + spMovePlayer);
        playerAnimatorController.SetBool("IsGrounded", player.isGrounded);
    }
        
}

