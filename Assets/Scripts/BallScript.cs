using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform StartPos;
   
    public GameObject BallShadow;
   
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(true);
        BallShadow?.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
       
        if (StartPos==null)
        {
            throw new UnityException("Start position missing!");

        }
        else
        {
            transform.position = StartPos.position;
        }
        if (rb == null)
        {
            throw new UnityException("Rigidbody2D component missing!");
        }
        else
        {
           
            StartCoroutine(BallThrow());
          

        }
    }

    IEnumerator BallThrow()
    {
        rb.isKinematic = true;
        yield return new WaitForSeconds(1f);
        rb.isKinematic = false;
        rb.AddForce(FindObjectOfType<BallForce>().BallForceVector);
    }

    void OnDrawGizmos()
    {
        if (StartPos == null)
        {
            throw new UnityException("Start position missing!");

        }
        else if (!Application.isPlaying)
        {
            this.gameObject.SetActive(true);
            transform.position = StartPos.position;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.collider.CompareTag("Basket")) {
                Debug.Log("success!!");
            BallShadow?.SetActive(true);
            this.gameObject.SetActive(false);
            }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
