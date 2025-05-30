using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnerFinal : MonoBehaviour
{
    public float StartTime=2f;
    private float currentTime;
    public float MinTime =0.2f;
    public GameObject ZombiePrefab;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = StartTime;
        StartCoroutine(Spawn());
        StartCoroutine(Spawn());
        StartCoroutine(Spawn());
    }

     IEnumerator Spawn()
    {
       
        switch (UnityEngine.Random.Range(0, 4)) { 
            case 0:
                Instantiate(ZombiePrefab, new Vector3(-ScreenBounds().x - 4, -ScreenBounds().y - 4, 0), Quaternion.identity);
        break;
            case 1:
                Instantiate(ZombiePrefab, new Vector3(ScreenBounds().x + 4, ScreenBounds().y + 4, 0), Quaternion.identity);
                break;
                case 2:
                Instantiate(ZombiePrefab, new Vector3(ScreenBounds().x+4, -ScreenBounds().y-4, 0),Quaternion.identity) ;
                break; 
            case 3:
                Instantiate(ZombiePrefab, new Vector3(-ScreenBounds().x - 4, ScreenBounds().y + 4, 0), Quaternion.identity);
                break;
        }
        
        yield return new WaitForSeconds(currentTime);
        if(currentTime>MinTime)UpdateTime();
        StartCoroutine(Spawn());
        StartCoroutine(Spawn());
        StartCoroutine(Spawn());
    }

    private void UpdateTime() {
    
        currentTime = StartTime - Time.timeSinceLevelLoad/60;

        if(currentTime<MinTime)currentTime=MinTime;
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector2 ScreenBounds()
    {
        
        
        return Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }
}
