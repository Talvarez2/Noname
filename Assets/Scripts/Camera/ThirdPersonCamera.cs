using System;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [Range (0, 1)] public float lerpValue;
    public bool x_track = false;

    //[SerializeField]
    public Vector3 _offset = new Vector3(0f,0f, -10f);
    public GameObject player_1;
    public GameObject player_2;
    private Vector3 targetPosition;

    private void Update() 
    {
        targetPosition = (player_1.transform.position + player_2.transform.position)/2;
        if (x_track) targetPosition = new Vector3(targetPosition.x, targetPosition.y, 0);
        else targetPosition = new Vector3(0, targetPosition.y, 0);
        transform.position = Vector3.Lerp(transform.position, targetPosition + _offset, lerpValue);
    }

    // public Vector3 offset;
    // private Transform target;
    // [Range (0, 1)] public float lerpValue;

    // // Update is called once per frame
    // void LateUpdate()
    // {
    //     if (target == null){
    //         target = GameObject.Find("Player(Clone)").transform;
    //     }
    //     transform.position = Vector3.Lerp(transform.position, target.position + offset, lerpValue);
    //     transform.LookAt(target);
    // }
}
