using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMover : MonoBehaviour
{

    public GameObject targetToMove;
    public float xPosInit;
    public float yPosInit;

    public float xOffset;
    public float yOffset;

    public float globalScale = 1f;


    // Start is called before the first frame update
    void Start()
    {
        xPosInit = targetToMove.transform.position.x;
        yPosInit = targetToMove.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {

        float yPos = -Input.mousePosition.x * globalScale + xOffset + xPosInit;
        float xPos = Input.mousePosition.y * globalScale + yOffset + yPosInit;

        targetToMove.transform.position = new Vector3(
            xPos,
            targetToMove.transform.position.y,
            yPos);




    }
}
