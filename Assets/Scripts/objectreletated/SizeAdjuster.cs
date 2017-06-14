//Brian Boersen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeAdjuster : MonoBehaviour
{
    private enum sizeState
    {
        idle = 0,
        startChanging = 1,
        changing = 2
    }

    [SerializeField]
    private float changeTime = 2f;
    private float changeStep,currentstep;

    private IEnumerator coroutine;

    private Vector3 mySize;

    private sizeState state;
    private sizeState lastState;

    Vector3 newSize;

    private void Start()
    {
        state = sizeState.idle;
        mySize = gameObject.transform.localScale;
        changeStep = 1f / (changeTime / 0.033f);
        StartCoroutine(sizeChange());
    }

    public void changeSize(Vector3 size)
    {
        newSize = RealObjectSize.fitInToSize(gameObject, size);
        state = sizeState.startChanging;
    }

    public void oldsize()
    {
        newSize = mySize;
        state = sizeState.startChanging;
    }

    private IEnumerator sizeChange()
    {
        while (true)
        {
            if(state == sizeState.idle)
            {
                
            }
            else if(state == sizeState.startChanging)
            {
                resetStep();
                state = sizeState.changing;
            }
            else if(state == sizeState.changing)
            {
                setStep();
                checkIfDone();             
            }

            yield return new WaitForSeconds(0.033f);
        }        
    }

    private void setStep()
    {
        currentstep += changeStep;

        gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, newSize, currentstep);
    }

    private void checkIfDone()
    {
        if (newSize == gameObject.transform.localScale)
        {
            state = sizeState.idle;
        }
    }

    private void resetStep()
    {
        currentstep = 0;
    }
}
