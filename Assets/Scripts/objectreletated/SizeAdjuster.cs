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

    private void Start()
    {
        state = sizeState.idle;
        mySize = gameObject.transform.localScale;
        changeStep = 1f / (changeTime / 0.033f);
    }

    public void changeSize(Vector3 newSize)
    {
        newSize = RealObjectSize.fitInToSize(gameObject,newSize);
        StartCoroutine(toNewSize(newSize));
    }

    public void oldsize()
    {
        StartCoroutine(toOldSize(mySize));
    }

    private IEnumerator toNewSize(Vector3 newSize)
    {
        while (true)
        {
            print(state);

            if (state == sizeState.growing)
            {
                yield return new WaitForSeconds(0.033f);
            }
            else if (state == sizeState.idle)
            {
                state = sizeState.shrinking;
                currentstep = 0;
            }

            currentstep += changeStep;

            gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, newSize, currentstep);

            if (newSize == gameObject.transform.localScale)
            {
                state = sizeState.idle;
                StopCoroutine(toNewSize(newSize));
            }

            yield return new WaitForSeconds(0.033f);
        }        
    }

    private IEnumerator toOldSize(Vector3 newSize)
    {
        while (true)
        {
            if (state == sizeState.shrinking)
            {
                yield return new WaitForSeconds(0.033f);
            }
            else if (state == sizeState.idle)
            {
                state = sizeState.growing;
                currentstep = 0;
            }

            currentstep += changeStep;

            gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, newSize, currentstep);

            if (newSize == gameObject.transform.localScale)
            {
                state = sizeState.idle;
                StopCoroutine(toOldSize(newSize));
            }

            yield return new WaitForSeconds(0.033f);
        }       
    }
}
