using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketScript : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        if(player == null) { throw new UnityException("Player is null"); }
        else
        {
            transform.position = player.position + new Vector3(15, -1.5f, 0);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        if (player == null)
        {
            throw new UnityException("Start position missing!");

        }
        else if (!Application.isPlaying)
        {
            transform.position = player.position+ new Vector3(15,-1.5f,0);
        }
    }
}
