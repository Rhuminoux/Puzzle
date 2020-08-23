using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pi_Stack : MonoBehaviour
{
    public List<GameObject> piecesStack;
    private int _i;
    
    void Start()
    {
        _i = piecesStack.Count;
    }

    public void init_Stack(int size)
    {
        _i = size;
        piecesStack = new List<GameObject>(size);
    }

    public GameObject getPiece()
    {
        if (_i > 0)
            return (piecesStack[--_i]);
        else
            return null;
    }

    void Update()
    {
        
    }
}
