using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public GameObject objectToMove;

    public GameObject targetA;
    public GameObject targetB;
    public GameObject targetC;
    public List<GameObject> targets;

    public float maxSpeed = 0.05f;
    public float speed = 0.01f;
    public float threshold = 0.01f;

    private GameObject currentTarget;
    private int targetIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        targets.Add(targetA);
        targets.Add(targetB);
        targets.Add(targetC);

        objectToMove.transform.localPosition = targets[0].transform.localPosition;
        currentTarget = targets[1];
    }

    // Update is called once per frame
    void Update()
    {
        speed = Mathf.Min(speed, maxSpeed);

        // where we are going from
        Vector3 currentPosition = objectToMove.transform.localPosition;

        // where we are going to
        Vector3 targetPosition = currentTarget.transform.localPosition;

        // where we want to be on that journey
        Vector3 newPosition = Vector3.MoveTowards(currentPosition, targetPosition, speed);

        // move to that place on our journey
        objectToMove.transform.localPosition = newPosition;

        // check if we have reached our destination
        float distanceToTarget = Vector3.Distance(newPosition, targetPosition);
        if (distanceToTarget < threshold)
        {
            // set our new destination
            targetIndex++;
            if (targetIndex >= targets.Count)
            {
                targetIndex = 0;
            }

            currentTarget = targets[targetIndex];
        }
    }
}
