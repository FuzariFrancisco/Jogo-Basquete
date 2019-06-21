using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Bola bola;

    public GameObject playerCamera;

    public float distanciaBola = 2f;

    public float ForcaArremesso = 550f;

    public bool SegurandoBola = true;

    // método Start é executado na criação do objeto
    void Start()
    {
        bola.GetComponent<Rigidbody>().useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (SegurandoBola)
        {
            bola.transform.position = playerCamera.transform.position + playerCamera.transform.forward * distanciaBola;

            if (Input.GetMouseButtonDown(0))
            {
                bola.AtivarTrilha();
                SegurandoBola = false;
                bola.GetComponent<Rigidbody>().useGravity = true;
                bola.GetComponent<Rigidbody>().AddForce(playerCamera.transform.forward * ForcaArremesso);
            }
        }
    }
}
