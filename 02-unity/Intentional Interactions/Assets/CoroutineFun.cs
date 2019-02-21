using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineFun : MonoBehaviour
{
    public GameObject objectToMove;

    private Coroutine printRoutine;
    private Coroutine moveRoutine;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (printRoutine != null)
            {
                StopCoroutine(printRoutine);
            }
            printRoutine = StartCoroutine(PrintAndWait());
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            bool isRoutineRunning = moveRoutine != null;
            if (isRoutineRunning)
            {
                StopCoroutine(moveRoutine);
                moveRoutine = null;
            }
            else
            {
                moveRoutine = StartCoroutine(MoveThing());
            }
        }
    }

    IEnumerator PrintAndWait()
    {
        Debug.Log("first thing");
        yield return new WaitForSeconds(1.6f);

        Debug.Log("second thing");
        yield return new WaitForSeconds(1.25f);

        Debug.Log("3333333");
        yield return new WaitForSeconds(2.0f);
    }

    IEnumerator MoveThing()
    {
        while (true)
        {
            objectToMove.transform.localPosition = new Vector3(
                Random.Range(0.0f, 1.0f),
                Random.Range(0.0f, 1.0f),
                Random.Range(0.0f, 1.0f)
            );
            yield return new WaitForSeconds(1.0f);
        }
    }
}
