using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallForce : MonoBehaviour
{
    public Vector2 BallForceVector;
    public TextMeshProUGUI TextMesh;

    public void OnDrawGizmos()
    {
        if(TextMesh!=null)
        TextMesh.text = "Otvori sila lopte objekat u inspektoru i ukucaj željene parametre vektora koji će se koristiti u rigidbody AddForce funkciji.\r\nPokreni igru kada si spreman da pokušaš da pogodiš koš.\r\n\r\nTrenutni kod koji se izvršava: rb.AddForce("+BallForceVector.x+","+BallForceVector.y+");";
    }
}
