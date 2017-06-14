//Brian Boersen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeAdjuster : MonoBehaviour
{
    private enum sizeState
    {
        idle = 0,
        shrinking = 1,
        growing
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
    }

    public void oldsize()
    {
        newSize = mySize;
    }

    private IEnumerator sizeChange()
    {
        while (true)
        {

            if(state == sizeState.idle && lastState != sizeState.idle)
            {
                resetStep();
            }
            else if(state == sizeState.growing && lastState != sizeState.growing)
            {
                resetStep();
            }
            else if(state == sizeState.shrinking && lastState != sizeState.shrinking)
            {
                resetStep();
            }

            setStep();

            checkIfDone();

            yield return new WaitForSeconds(0.033f);

            ////////////////////////////////////////////////
            /*if (state == sizeState.growing)
            {
                yield return new WaitForSeconds(0.033f);
            }
            else if (state == sizeState.idle)
            {
                state = sizeState.shrinking;
                currentstep = 0;
            }
            print(state);

            currentstep += changeStep;

            gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, newSize, currentstep);

            if (newSize == gameObject.transform.localScale)
            {
                state = sizeState.idle;
            }*/

            
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
