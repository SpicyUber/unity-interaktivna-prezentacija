using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScriptFinal : MonoBehaviour
{
    private float speed = 350f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fly(Vector3 direction) { 
    
        GetComponentInChildren<Rigidbody2D>().AddForce((Vector2)direction*speed);
        StartCoroutine(SelfDestruct());
    
    }

    private IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(5f);
        this.gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
