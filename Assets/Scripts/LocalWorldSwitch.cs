using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LocalWorldSwitch : MonoBehaviour
{
  
    [SerializeField]
    [Header("World Or Local?")]

    bool isShowingWorld;
    [SerializeField]
    [Header("World Or Local?")]
    bool showCoordinateSystem;
    [Header("*\n*\n*\n*\n*\n*\n*\n*\n*\n*\n*\n*\n")]
    [Header("---DO NOT CHANGE---")]
    [SerializeField]
    GameObject worldLines;
        [SerializeField]
       GameObject localLines;
    [SerializeField]
    GameObject localText1, localText2, localText3;
    [SerializeField]
    GameObject worldText1, worldText2, worldText3;
    [SerializeField]
    Button button;
    [SerializeField]
    Color color1, color2;
    [SerializeField]
    GameObject coords1, coords2, coords3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDrawGizmos() {

        coords1.transform.localPosition = Vector3.zero;
        coords2.transform.localPosition = Vector3.zero;
        coords3.transform.localPosition = Vector3.zero;
        coords1.transform.localRotation = Quaternion.identity;
        coords2.transform.localRotation = Quaternion.identity;
        coords3.transform.localRotation= Quaternion.identity;
        coords1.transform.localScale = Vector3.one;
        coords2.transform.localScale = Vector3.one;
        coords3.transform.localScale = Vector3.one;
        if (!isShowingWorld)
        {

            button.GetComponentInChildren<TextMeshProUGUI>().text = "Local";
            button.GetComponent<Image>().color = new Color(color2.r, color2.g, color2.b, 0.75f);
            worldLines.SetActive(false);
            worldText1.SetActive(false);
            worldText2.SetActive(false);
            worldText3.SetActive(false);
            localLines.SetActive(true);
            localText1.SetActive(true);
            localText2.SetActive(true);
            localText3.SetActive(true);

        }
        else {
            button.GetComponentInChildren<TextMeshProUGUI>().text = "World";
            button.GetComponent<Image>().color = new Color(color1.r, color1.g, color1.b, 0.75f);
            worldLines.SetActive(true);
            worldText1.SetActive(true);
            worldText2.SetActive(true);
            worldText3.SetActive(true);
            localLines.SetActive(false);
            localText1.SetActive(false);
            localText2.SetActive(false);
            localText3.SetActive(false);

        }

        if (showCoordinateSystem) {
        coords1.SetActive(true);
            coords2.SetActive(true);
            coords3.SetActive(true);
        } else
        {
            coords1.SetActive(false);
            coords2.SetActive(false);
            coords3.SetActive(false);
        }
    }
}
