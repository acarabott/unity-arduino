using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Timer : MonoBehaviour
{
    public GameObject objectToMove;

    private Coroutine printRoutine;
    private Coroutine moveRoutine;
    
    void Start()
    {

    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (printRoutine != null)
            {
                StopCoroutine(printRoutine);
            }
            printRoutine = StartCoroutine(PrintWithTiming());
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            if (moveRoutine == null)
            {
                moveRoutine = StartCoroutine(MoveAbout());
            }
            else
            {
                StopCoroutine(moveRoutine);
                moveRoutine = null;
            }

        }

    }

    IEnumerator PrintWithTiming()
    {
        Debug.Log("One");
        yield return new WaitForSeconds(1.0f);

        Debug.Log("Two");
        yield return new WaitForSeconds(0.5f);

        Debug.Log("Two");
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator MoveAbout()
    {
        while (true)
        {
            objectToMove.transform.localPosition = new Vector3(
                Random.Range(0f, 2f),
                Random.Range(0f, 2f),
                Random.Range(0f, 2f)
            );
            yield return new WaitForSeconds(1f);
        }

    }
}
