using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScriptFinal : MonoBehaviour
{
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new(Player.position.x,Player.position.y,0);
    }
}
