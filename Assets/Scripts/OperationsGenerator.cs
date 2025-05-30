using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;

public class OperationsGenerator : MonoBehaviour
{
    public enum OperationType {
        ADD = 0, SUBTRACT, DOTPRODUCT
}
    
    public bool isTurnedOn;
    public OperationType operation;
    public bool showSubtractOnOrigin;
    [SerializeField] Vector A, B;
    [Header("---DO NOT TOUCH---")]
    [SerializeField] GameObject VectorPrefab, linePrefab;
    private TextMeshProUGUI cText;
    private TextMeshProUGUI vectorMessage;

    private Vector C;
    private LineTiny L, L2;
    private GameObject vectorGameObject;
    private GameObject startObj, endObj,startObj2,endObj2;
   
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

        if (A == null || B == null) {
            if(L!=null) { L.gameObject.SetActive(false); vectorMessage.text = ""; }
            if (L2 != null) { L2.gameObject.SetActive(false); }
            return; }
       if (vectorMessage==null) { vectorMessage = GameObject.FindGameObjectWithTag("VectorMessage2").GetComponent<TextMeshProUGUI>(); }
        vectorMessage.text = "";
        Vector2 a = A.vector;
        Vector2 b = B.vector;
       
        if(C==null || vectorGameObject == null) { 
        vectorGameObject = Instantiate(VectorPrefab,this.transform);
        C = vectorGameObject.GetComponent<Vector>();
           cText = C.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();

        }
        if (L == null || L2 == null)
        {
            L = Instantiate(linePrefab, this.transform).GetComponent<LineTiny>();
            L2 = Instantiate(linePrefab, this.transform).GetComponent<LineTiny>();

        }
        if( startObj==null || endObj == null || startObj2==null || endObj2==null)
        {
            startObj = new GameObject();
            endObj = new GameObject();
            startObj2 = new GameObject();
            endObj2 = new GameObject();
        }
        L.gameObject.SetActive(false);
        L2.gameObject.SetActive(false);
        if (!isTurnedOn) { vectorGameObject.SetActive(false); return; }
        vectorGameObject.SetActive(true);
        A.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text ="A: "+ A.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text;
        B.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text ="B: "+ B.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text;
        cText.text ="C: "+cText.text; 

        switch (operation)
        {
            case OperationType.ADD:
                C.origin = A.origin;
                cText.gameObject.SetActive(true);


                //   C.vector = a + b;
               
                C.vector = new Vector2(a.x+b.x,a.y+b.y);
                vectorMessage.text = "C = A+B = (A.x + B.x , A.y + B.y) = " + "("+ Math.Round(C.vector.x, 2) + "," + Math.Round(C.vector.y, 2) + ")";


                break; 
            
            case OperationType.SUBTRACT: 
                // C.vector = a - b;
                C.vector = new Vector2(a.x - b.x, a.y - b.y);
                if (!showSubtractOnOrigin) { C.origin = B.gameObject; cText.gameObject.SetActive(false); } else { C.origin = A.origin; cText.gameObject.SetActive(true);

                }
                vectorMessage.text = "C = A-B = (A.x - B.x , A.y - B.y) = " + "(" + Math.Round(C.vector.x,2) + "," + Math.Round(C.vector.y, 2) + ")";
                break;
            case OperationType.DOTPRODUCT:
                C.origin = A.origin;
                cText.gameObject.SetActive(true);
                vectorGameObject.SetActive(false);
                string bonusMessage = "Sta se desi ako nomralizujemo jedan vektor?\n(Normalizovani vektor je vektor cija je duzina = 1)";
                if(new Vector2(A.vector.x, A.vector.y).Equals( new Vector2(A.vector.x,A.vector.y).normalized) && !new Vector2(B.vector.x, B.vector.y).Equals(new Vector2(B.vector.x, B.vector.y).normalized))
                {
                    L.gameObject.SetActive(true);
                    L2.gameObject.SetActive(true);
                    
                    startObj.transform.position= B.vector;
                    endObj.transform.position = A.vector * Vector2.Dot(a, b);
                    startObj2.transform.position = A.vector * (-1000); 
                    endObj2.transform.position = A.vector* 1000;
                    L.startObj = startObj; L.endObj = endObj;
                    L2.startObj = startObj2; L2.endObj = endObj2;
                    bonusMessage = "Skalarni proizvod nam daje projekciju\n nenormalizovanog vektora na pravac \nnormalizovanog vektora.\nSta se desi ako normalizujemo oba vektora?\n(Normalizovani vektor je vektor cija je duzina = 1)";

                }
                else if (!new Vector2(A.vector.x, A.vector.y).Equals(new Vector2(A.vector.x, A.vector.y).normalized) && new Vector2(B.vector.x, B.vector.y).Equals(new Vector2(B.vector.x, B.vector.y).normalized))
                {
                    L.gameObject.SetActive(true);
                    bonusMessage = "Skalarni proizvod nam daje projekciju\n nenormalizovanog vektora na pravac \nnormalizovanog vektora.\nSta se desi ako normalizujemo oba vektora?\n(Normalizovani vektor je vektor cija je duzina = 1)";
                    L2.gameObject.SetActive(true);
                   

                    startObj.transform.position = A.vector;
                    endObj.transform.position = B.vector * Vector2.Dot(a, b);
                    startObj2.transform.position = B.vector * (-1000);
                    endObj2.transform.position = B.vector * 1000;
                    L.startObj = startObj; L.endObj = endObj;
                    L2.startObj = startObj2; L2.endObj = endObj2;
                }
                else if (new Vector2(A.vector.x, A.vector.y).Equals(new Vector2(A.vector.x, A.vector.y).normalized) && new Vector2(B.vector.x, B.vector.y).Equals(new Vector2(B.vector.x, B.vector.y).normalized))
                {
                    L.gameObject.SetActive(true);
                    bonusMessage = "Oba vektora su normalizovana!\nSkalarni proizvod nam sada daje\nkosinus ugla dva vektora.";
                    startObj.transform.position = B.vector;
                    endObj.transform.position = A.vector * Vector2.Dot(a, b);
                    L.startObj = startObj; L.endObj = endObj;
                }
                vectorMessage.text = "C = A*B = A.x * B.x + A.y * B.y = " + Math.Round(Vector2.Dot(a, b),2) + "\n"+bonusMessage;
                break;
               


        }
    }
}
