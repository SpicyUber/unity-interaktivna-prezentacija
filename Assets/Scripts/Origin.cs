using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Origin : MonoBehaviour
{

    [SerializeField] GameObject tile;
    [SerializeField] Color c1, c2;
    [SerializeField] int tilemapWidth;
    [SerializeField] bool visible;
    private bool areTilesInst;
   
    // Start is called before the first frame update
    void Start()
    {
        if (areTilesInst)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Vector3 tempLocalScale = transform.localScale;
        Vector3 tempPos = transform.position;

        if(!areTilesInst && tilemapWidth>0)
        {
           
            DeleteTiles();
            this.transform.position = Vector3.zero;

            this.transform.localScale = Vector3.one;
            GameObject t;
            int k = 1;
            for (int i = -tilemapWidth/2; i < tilemapWidth / 2; i++) {
                for (int j = -tilemapWidth / 2; j < tilemapWidth / 2; j++) { 
                  t =  Instantiate(tile,GameObject.FindGameObjectWithTag("Tiles").transform);
                t.transform.position = new Vector3(i, j, 0);
                    if (k % 2 == 0) { t.GetComponentInChildren<SpriteRenderer>().color = new Color(c1.r,c1.g,c1.b,c1.a); } else t.GetComponentInChildren<SpriteRenderer>().color = new Color(c2.r, c2.g, c2.b, c2.a);
                    k++;
                }
                k++;
            }
            areTilesInst = true;
        }
        transform.localScale = tempLocalScale;
        transform.position = tempPos;
        this.transform.rotation = Quaternion.identity;

        if (visible) { 
        Gizmos.color = Color.red;
        Gizmos.DrawLine(Vector3.zero, Vector3.right* tilemapWidth / 2);
        Gizmos.DrawLine(Vector3.zero, -Vector3.right* tilemapWidth / 2);
        Gizmos.color = Color.green;

        Gizmos.DrawLine(Vector3.zero, Vector3.up * tilemapWidth / 2);
        Gizmos.DrawLine(Vector3.zero, -Vector3.up * tilemapWidth / 2);
        }
    }

    void DeleteTiles()
    {
        GameObject[] gO =GameObject.FindGameObjectsWithTag("Tile");
        for(int x = 0; x < gO.Length; x++)
        {
            DestroyImmediate(gO[x]);
        }
    }
}
