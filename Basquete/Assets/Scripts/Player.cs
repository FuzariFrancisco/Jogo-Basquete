using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Bola bola;
    public GameObject bolaObj;

    public GameObject playerCamera;

    public float distanciaBola = 2f;

    public float forcaArremesso = 0f;

    public bool segurandoBola = true;
    bool saiu = false;


   

    // Metodo start é executado apenas na criação do objeto
    void Start()
    {
        bola.GetComponent<Rigidbody>().useGravity = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (saiu)
        {
                bola.objetoTrilha.SetActive(false);
                segurandoBola = true;
                bola.GetComponent<Rigidbody>().useGravity = false;
                saiu = false;
        }

        if (segurandoBola)
        {
            bola.transform.position = playerCamera.transform.position + playerCamera.transform.forward * distanciaBola;
            if (Input.GetMouseButton(0))
            {
                if (forcaArremesso<1000)
                {
                    forcaArremesso+=15;
                    Debug.Log(forcaArremesso);
                }
                
            }

            if (Input.GetMouseButtonUp(0))
            {
                bola.ParaRotacao();
                bola.AtivarTrilha();
                segurandoBola = false;
                bola.GetComponent<Rigidbody>().useGravity = true;
                bola.GetComponent<Rigidbody>().AddForce(playerCamera.transform.forward * forcaArremesso);
                forcaArremesso = 0;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == bolaObj)
        {
            bola.objetoTrilha.SetActive(false);
            segurandoBola = true;
            bola.GetComponent<Rigidbody>().useGravity = false;
        }
    }

    public void VoltaBola()
    {
        saiu = true;
    }
}
