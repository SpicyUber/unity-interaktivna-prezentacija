using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MinigameScript : MonoBehaviour
{
    public GameObject mold;
    public GameObject ape;
    private Vector3[] localRotations = {new Vector3(0,0,0),new Vector3(0,0,60),new Vector3(0, 0, -90)};
    private Vector3[] localScales = { new Vector3(1, 1, 1), new Vector3(1, 1, 1), new Vector3(2, 4, 0) };
    private Vector3[] localPos = { new Vector3(0, 15, 0), new Vector3(4, -2, 0), new Vector3(-5, 3, 0) };
    private int currentMoldIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        //lock scale ,rotation, position
        transform.localScale = Vector3.one;
        transform.localRotation = Quaternion.identity;
       // transform.position = new Vector3(-999, -999, 0);

        if(RotationCheck() && ScaleCheck() && PosCheck()) { 
            
            currentMoldIndex++; 
            
            if(currentMoldIndex >= localPos.Length) { currentMoldIndex = 0; }
        

        }
    
        mold.transform.localPosition = localPos[currentMoldIndex];
        mold.transform.localRotation = Quaternion.Euler(  localRotations[currentMoldIndex]);
        mold.transform.localScale = localScales[currentMoldIndex];
    }

    private bool PosCheck()
    {
        return (((Vector2)ape.transform.position - (Vector2)mold.transform.position).magnitude < 0.5f);
    }

    private bool ScaleCheck()
    {
        return (((Vector2)ape.transform.localScale - (Vector2)mold.transform.localScale).magnitude < 0.3f);
    }

    private bool RotationCheck()
    {
        return Vector2.Dot(((Vector2)ape.transform.up).normalized, ((Vector2)mold.transform.up).normalized) > 0.8f && Vector2.Dot(((Vector2)ape.transform.right).normalized, ((Vector2)mold.transform.right).normalized) > 0.8f;
    }
}
