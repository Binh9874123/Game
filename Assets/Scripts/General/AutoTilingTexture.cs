using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTilingTexture : MonoBehaviour
{
    private float lowerValue = 0.01f; //if side size <= lowerValue - tiling uses for another two sizes

    private void Awake()
    {
        float x, y, z;
        x = this.transform.localScale.x;
        y = this.transform.localScale.y;
        z = this.transform.localScale.z;

        float side1, side2;

        if (x <= lowerValue)
        {
            side1 = y;
            side2 = z;
        }
        else if (y <= lowerValue)
        {
            side1 = x;
            side2 = z;
        }
        else
        {
            side1 = x;
            side2 = y;
        }

        GetComponent<MeshRenderer>().material.mainTextureScale = new Vector3(side1, side2);
    }   

}
