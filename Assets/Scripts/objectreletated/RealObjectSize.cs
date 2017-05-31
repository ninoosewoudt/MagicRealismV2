//Brian Boersen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RealObjectSize
{
    public static bool realSizeCheck(Vector3 boundSize,Vector3 sizeInMeters)
    {
        if (sizeInMeters == boundSize)
            return true;
        else
            return false;
    }

    public static Vector3 fitInToSize(GameObject gameObj, Vector3 sizeInMeters)
    {
        Vector3 boundSize = gameObj.GetComponent<MeshRenderer>().bounds.size;

        float biggest = Mathf.Max(boundSize.x, boundSize.y, boundSize.z);
        float smallest = Mathf.Min(sizeInMeters.x, sizeInMeters.y, sizeInMeters.z);

        float newSize = smallest / biggest;

        float newX = gameObj.transform.localScale.x * newSize;
        float newY = gameObj.transform.localScale.y * newSize;
        float newZ = gameObj.transform.localScale.z * newSize;

        return new Vector3(newX, newY, newZ);

    }

    public static Vector3 convertObjectSize(GameObject gameObj, Vector3 sizeInMeters)
    {
        Vector3 boundSize = gameObj.GetComponent<MeshRenderer>().bounds.size;

        if (realSizeCheck(boundSize, sizeInMeters) == false)
        {
            float newX = gameObj.transform.localScale.x * (sizeInMeters.x / boundSize.x);
            float newY = gameObj.transform.localScale.y * (sizeInMeters.y / boundSize.y);
            float newZ = gameObj.transform.localScale.z * (sizeInMeters.z / boundSize.z);
            return new Vector3(newX,newY,newZ);
        }

        return gameObj.transform.localScale;   
    }

    public static Vector3 boundSize(GameObject gameObj)
    {
        Vector3 size = gameObj.GetComponent<MeshFilter>().sharedMesh.bounds.size;
        return size;
    }
}
