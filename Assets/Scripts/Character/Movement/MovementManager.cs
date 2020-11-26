using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    // Vector3

    //Dictionary of arrays. Length 3. Static Movement, dynamic Movement, force Movement in order.
    public IDictionary<string, Vector3[]> Vector3Stack = new Dictionary<string, Vector3[]>(); 
    public CharacterController player;

    private Vector3 staticMovement;
    private Vector3 dynamicMovement = new Vector3(0,0,0);
    private Vector3 testVector = new Vector3(1,0,0);
    private Vector3 forceMovement;
    private Vector3 totalMovement;


    private int max_dist = 20;
    float dot;
    private bool ropeOn = true;

    private int playerNum;
    private Vector3 projection, position_delta;
    public Animator playerAnimatorController;

    void Start(){
        player = GetComponentInParent<CharacterController>();
        playerNum = GetComponentInParent<PlayerData>().playerNum;

    }

    void Update(){
        staticMovement = new Vector3(0,0,0);
        if (player.isGrounded) dynamicMovement = new Vector3(0,0,0);
        forceMovement  = new Vector3(0,0,0);
        totalMovement  = new Vector3(0,0,0);

        foreach (KeyValuePair<string,Vector3[]> kvp in Vector3Stack){
            staticMovement  += kvp.Value[0];
            dynamicMovement += kvp.Value[1] * Time.deltaTime;
            forceMovement   += kvp.Value[2];
        }
        
        dynamicMovement += forceMovement;
        
        totalMovement = staticMovement + dynamicMovement;
        if (ropeOn){
            projection = GetComponent<RopeMover>().ropeFunction(totalMovement);
            position_delta = GetComponent<RopeMover>().dotFunc(totalMovement);
            dynamicMovement -= projection*Time.deltaTime;
            staticMovement += position_delta;
            totalMovement = staticMovement + dynamicMovement;
        }        

        player.Move(totalMovement * Time.deltaTime);
        playerAnimatorController.SetBool("IsGrounded", player.isGrounded);
    }

     void OnGUI(){
 
        // GUI.Label(new Rect(50,20,200,100),"Y pos = " + player.transform.position.y.ToString("0.00"));
        GUI.Label(new Rect(50 + (400*(playerNum-1)),30,200,100),"Static = "  + staticMovement.ToString());
        GUI.Label(new Rect(50 + (400*(playerNum-1)),40,200,100),"Dynamic = " + dynamicMovement.ToString());
        GUI.Label(new Rect(50 + (400*(playerNum-1)),50,200,100),"Force = "   + forceMovement.ToString());
        GUI.Label(new Rect(50 + (400*(playerNum-1)),60,200,100),"Total = "   + totalMovement.ToString());
        GUI.Label(new Rect(50 + (400*(playerNum-1)),70,200,100),"Projection = "   + projection.ToString());
        GUI.Label(new Rect(50 + (400*(playerNum-1)),80,200,100),"Dot = "   + dot.ToString());
        
    }
        
}

