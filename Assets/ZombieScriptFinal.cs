using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ZombieScriptFinal : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
       transform.up = (player.transform.position - this.transform.position).normalized;
    }

    private void FixedUpdate()
    {
       
       rb  = GetComponent<Rigidbody2D>();
       if(player!=null && player.active) rb.velocity=((player.transform.position - this.transform.position).normalized * 2f );
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
           collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else if(collision.collider.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
            GameOver();
            
        }
    }

    void GameOver()
    {
        GameObject.FindWithTag("GameOver").GetComponent<TextMeshProUGUI>().text="GAME OVER";
        PlayerPrefs.SetFloat("HighScore", Time.timeSinceLevelLoad);
        Debug.Log("GAME OVER!");
        return;
    }
}
