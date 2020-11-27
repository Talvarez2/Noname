using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    private Node[] pathNode;
    private float startTime;
    private Vector3 targetPosition;
    private Vector3 initialPosition;
    private float totalDistance;
    private float coveredDistance;
    private int currentNode = 0;
    public float moveSpeed;

    void Start()
    {
        pathNode = transform.parent.GetComponentsInChildren<Node>();
        NextNode();
    }

    void Update()
    {
        coveredDistance = (Time.time - startTime) * moveSpeed;

        if (transform.position != targetPosition)
        {
            transform.position = Vector3.Lerp(initialPosition, targetPosition, coveredDistance / totalDistance);
        }
        else
        {
            NextNode();
        }
    }

    private void NextNode()
    {
        startTime = Time.time;
        initialPosition = transform.position;
        currentNode += 1;
        if (currentNode == pathNode.Length)
        {
            currentNode = 0;
        }
        targetPosition = pathNode[currentNode].transform.position;
        totalDistance = Vector3.Distance(initialPosition, targetPosition);
    }
}
