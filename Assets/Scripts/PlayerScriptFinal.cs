using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerScriptFinal : MonoBehaviour
{
    public TextMeshProUGUI HighScore;
    public GameObject BulletPrefab;
    public Transform Gun;
    public float ShootCooldown;
    private bool cooldownActive;
    private Vector2 movementDir;
    private float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        float timeInSeconds = PlayerPrefs.GetFloat("HighScore");
        float seconds = timeInSeconds % 60;
        float minutes = timeInSeconds / 60;
        HighScore.text = $"\n\nHIGH SCORE\n{(int)minutes}:{(int)seconds} ";

    }

    // Update is called once per frame
    void Update()
    {
        movementDir = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y).magnitude>1)
        {
            transform.up= new Vector2(mousePos.x-transform.position.x, mousePos.y - transform.position.y).normalized;
        }
        if (Input.GetMouseButtonDown(0)) {
            Shoot();
        
        }
        transform.Translate(speed * Time.deltaTime * movementDir, Space.World);
    }

    private void Shoot()
    {
        if(cooldownActive)return;
        cooldownActive = true;
      GameObject bf =  Instantiate(BulletPrefab, Gun.position, Quaternion.identity);
        bf.GetComponent<BulletScriptFinal>().Fly(Gun.up);
        StartCoroutine(Cooldown());
    }
    IEnumerator Cooldown()
    {


        yield return new WaitForSeconds(ShootCooldown);
        cooldownActive = false;
    }
}
