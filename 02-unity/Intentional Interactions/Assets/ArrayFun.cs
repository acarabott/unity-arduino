using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayFun : MonoBehaviour
{
    public GameObject gameObjectToMove;
    public List<Vector3> storedPositions = new List<Vector3>();
    public bool isRecording = false;
    public Vector3[] positions =
        {
            new Vector3(0f, 0f, 0f),
            new Vector3(1f, 0f, 0f),
            new Vector3(1f, 1f, 0f),
            new Vector3(0f, 1f, 0f),
            new Vector3(0f, 0f, 0f),
        };

    private int positionIndex = 0;
    private int storedPositionIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameObjectToMove.transform.localPosition = positions[positionIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            positionIndex++;
            if (positionIndex >= positions.Length)
            {
                positionIndex = 0;
            }
            gameObjectToMove.transform.localPosition = positions[positionIndex];
        }

        else if (Input.GetKeyDown(KeyCode.S) || isRecording)
        {
            storedPositions.Add(gameObjectToMove.transform.localPosition);
        }

        else if (Input.GetKey(KeyCode.M) && storedPositions.Count > 0)
        {
            storedPositionIndex++;
            if (storedPositionIndex >= storedPositions.Count)
            {
                storedPositionIndex = 0;
            }
            gameObjectToMove.transform.localPosition = storedPositions[storedPositionIndex];
        }

        //gameob
    }
}
