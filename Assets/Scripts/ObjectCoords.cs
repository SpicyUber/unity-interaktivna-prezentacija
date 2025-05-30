using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectCoords : MonoBehaviour
{
    [SerializeField] GameObject obj;
    [SerializeField] TextMeshProUGUI localText, worldText;
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
     if(localText!=null) localText.text ="lPos x,y: "+ CalculateLocal();
     if (worldText != null) worldText.text ="wPos x,y: "+ CalculateWorld();
    }

    //Kako doci do world pozicije ako su nam date samo lokalne pozicije objekata?
    private string CalculateWorld()
    {
       
        //Svaki objekat ima svoj kordinatni sistem. Kada jedan covek objasnjava nesto drugom cesto se desi da "njegovo desno" nije isto kao i desno osobe sa kojom prica.
        //Takodje kada ja uperim prst u svoje "gore" to sigurno nije isti pravac kao kada bi neko iz Australije uradio isto.
        //Svaki objekat ima svoje "desno" i svoje "gore" i njima pristupamo pomocu transform.up i transform.right.
        //Obzirom da se svako dete pomera desno i gore po kordinatnom sistemu svoga roditelja potrebno je pomeriti se za x u njegovo "desno" i za y u njegovo "gore".
        Transform head = this.transform;
        Vector2 placeholderVector= Vector2.zero;
        //Pomeramo se u desno roditelja za x i gore za y sve dok dodjemo do objekta bez roditelja. 
        while (head.parent != null)
        {
            placeholderVector = placeholderVector + (Vector2)(head.parent.right * head.localPosition.x)+ (Vector2)(head.parent.up * head.localPosition.y);
            head = head.parent;
        }
        //Objekat bez roditelja se pomera po world space orijentaciji koja nema rotaciju.
        //Njeno desno i gore je normalno ocekivano desno i gore (poklapa se sa x i y osom kartesijanskog koordinatnog sistema).
        //Koriscenjem Vector2.right i Vector2.up mozemo na brz nacin dobiti te podrazumevane vrednosti (1,0) i (0,1).
        placeholderVector = placeholderVector + Vector2.right * head.localPosition.x + Vector2.up * head.localPosition.y;


        return $"{Math.Round(placeholderVector.x, 2)},{Math.Round(placeholderVector.y, 2)}";
    }

    //Kako doci do local pozicije ako su nam date samo world pozicije objekata?
    private string CalculateLocal()
    {
        //Vec smo spomenuli da svaki objekat ima svoje levo i svoje desno, tj svoj kordinatni sistem,
        //Mozemo izracunati gde se dete nalazi u kordinatnom sistemu svog roditelja tako sto izracunamo projekciju deteta na x osu i projekciju na y osu roditelja.
        //Koristimo skalarni proizvod vektora world pozicije i x ose i y ose.
        Vector2 placeholderVector;
        Transform parent = transform.parent;
        //u slucaju da nema roditelja world pozicija je jednaka local poziciji
        if (parent == null) return $"{transform.position.x},{transform.position.y}";
        placeholderVector.x = Vector2.Dot(this.transform.position - parent.transform.position, parent.right );
        placeholderVector.y = Vector2.Dot(this.transform.position - parent.transform.position, parent.up);


        return $"{Math.Round(placeholderVector.x,1)},{Math.Round(placeholderVector.y, 1)}";
    }
}
