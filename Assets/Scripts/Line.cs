using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField]
   public GameObject startObj, endObj,arrow;
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
        this.transform.localScale = new Vector3(0.5f, 0.5f);
        if (startObj==null||endObj==null) { return; }
        this.transform.position = new Vector3((startObj.transform.position.x + endObj.transform.position.x) / 2, (startObj.transform.position.y + endObj.transform.position.y)/2, 1);
        this.GetComponent<SpriteRenderer>().size = new Vector2(2 * ((Vector2)endObj.transform.position - (Vector2)startObj.transform.position).magnitude, 4);
        Vector3 rotationVector = Quaternion.Euler(0, 0, 90) * (endObj.transform.position - startObj.transform.position).normalized;
        this.transform.localRotation = Quaternion.LookRotation(Vector3.forward, rotationVector);
        if (arrow != null) { 
        arrow.transform.position = endObj.transform.position+2.8f*(  startObj.transform.position -endObj.transform.position).normalized + 0.3f*this.transform.up ;
        arrow.transform.localScale = new Vector3(2, 2, 0);
        }
    }
}
