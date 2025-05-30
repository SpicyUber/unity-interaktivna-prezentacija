using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.NetworkInformation;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class Vector : MonoBehaviour
{
    [SerializeField] public Vector2 vector;
    [SerializeField] public bool isNormalized;
    
    private SpriteRenderer sprite;
   
    private Color color=Color.clear;
    private TextMeshProUGUI vectorMessage;
    private string errorMessage = "";
    private bool displayedError=false;
    
    private bool isOperationsVector;
    private int vectorId=-1;
    private TextMeshProUGUI textField;
    [HideInInspector]
    public GameObject origin;
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

       


        //pomocu GetComponent<TipKomponente>() pronalazimo zeljenu komponentu GameObject-a.
        if (sprite==null){ sprite = GetComponent<SpriteRenderer>(); }
        //pomocu GameObject.Find...() funkcija pronalazimo zeljeni GameObject kako bismo ga koristili preko trenutnog GameObject-a.
        if (origin == null) { origin= GameObject.FindWithTag("Origin"); }
        //Umesto da svaki put pozivamo GetComponent i FindWithTag mi njihov rezultat dodeljujemo atributu i time postizemo optimizaciju koda. To se ukratko zove "Kesiranje".


        

        if (vectorMessage == null) {
            vectorMessage = GameObject.FindWithTag("VectorMessage").GetComponent<TextMeshProUGUI>(); 
        
        }
        if (color.CompareRGB(Color.clear)){
            color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }
        if (textField == null) {
            textField = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
           
        }
        if (vectorId == -1)
        {
            if(transform.parent!=null)
            isOperationsVector = transform.parent.CompareTag("Operations");
            GameObject[] gObjs = GameObject.FindGameObjectsWithTag("Vector");
            int i = 1;
            foreach (GameObject obj in gObjs)
            {
                if (obj.Equals(this.gameObject)) { vectorId = i; break; }
                i++;
            }
            if (!isOperationsVector) errorMessage = $"\n ERROR: Vektor{vectorId} nije dete kordinatnog sistema. Vektori moraju biti deca komponente kordinatnog sistema.";
            else errorMessage = $"\n ERROR: Vektor{vectorId} je rezultat operacije. Potrebno je vratiti ga u poziciju deteta objekta Operations.";
            this.gameObject.name = "Vector" + vectorId; }
        if(isOperationsVector) { isNormalized = false; }
        if (isNormalized)
        {
            vector = vector.normalized;
        }
        if (origin != null && sprite!=null && !color.CompareRGB(Color.clear) && vectorMessage!=null &&textField!=null) { 
       
        Gizmos.color = color;
            sprite.color = color;
            textField.color = color;

            transform.localPosition= vector+ (Vector2)origin.transform.position;
            transform.up = ( vector).normalized; 

            Vector3 originVector = origin.transform.position;
            originVector.z = originVector.z + 100;
            Vector3 positionVector = transform.position;
            positionVector.z = positionVector.z + 100;

            Gizmos.DrawLine(originVector, positionVector);
            textField.transform.up = Vector3.up;
            textField.text = $"{vector.x},{vector.y}\n\n\n";

        }
        
        if (transform.parent ==null && !displayedError )
        {
            vectorMessage.text = vectorMessage.text + errorMessage;
            displayedError = true;
        }
        else if(isOperationsVector &&(transform.parent == null||!transform.parent.CompareTag("Operations")) && !displayedError)
        {
            vectorMessage.text = vectorMessage.text + errorMessage;
            displayedError = true;


        }
           else if ((transform.parent == null ||(transform.parent.CompareTag("Origin")) && isOperationsVector) && !displayedError)
        {

            vectorMessage.text = vectorMessage.text + errorMessage;
            displayedError = true;

        }
        else if (displayedError && transform.parent!=null && ((transform.parent.CompareTag("Origin") && !isOperationsVector) ||(transform.parent.CompareTag("Operations") && isOperationsVector)))
        {
            vectorMessage.text = vectorMessage.text.Replace(errorMessage.ToString(), "");
            displayedError = false;
        }

        if (vectorMessage.text.Contains("-1")) { vectorMessage.text = ""; }

        if (isNormalized) { sprite.color = Color.clear; textField.fontSize = 2f; }else { textField.fontSize = 24; }

    }
}
