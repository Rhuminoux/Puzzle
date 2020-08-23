using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pi_Bar_Emp : MonoBehaviour
{

    public bool taken;
    
    void Update()
    {
        if (transform.childCount == 0)
            taken = false;
        else
            taken = true;
    }

    public Vector3 getPos()
    {
        return this.gameObject.transform.position;
    }
}
