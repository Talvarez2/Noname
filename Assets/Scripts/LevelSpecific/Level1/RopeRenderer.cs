using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeRenderer : MonoBehaviour
{
    public CharacterController player1;
    public CharacterController player2;
    public int maxDist = 20;
    public Color color1 = new Color(0_5f, 0, 0, 1);
    public Color color2 = new Color(0, 0_5f, 0, 1);
    public Color color3 = new Color(0, 0_5f, 0, 1);



    private Vector3[] characterPositions = {new Vector3(), new Vector3()};
    private float distance;
    private float alpha;
    private LineRenderer ropeRenderer;
    private Color fColor;
    // Start is called before the first frame update
    void Start()
    {
        ropeRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {   
        characterPositions[0] = player1.transform.position;
        characterPositions[1] = player2.transform.position;
        ropeRenderer.SetPositions(characterPositions);

        distance = Vector3.Distance(player1.transform.position,player2.transform.position);
        alpha = distance/maxDist;
        if (maxDist-distance<0.1){
            fColor = color3;
        }
        else{
            fColor = color2*alpha + color1*(1-alpha);
        }
        ropeRenderer.material.color = fColor;
    }
}
