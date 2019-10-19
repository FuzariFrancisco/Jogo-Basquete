using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    public GameObject objetoTrilha;
    Rigidbody Rb;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        objetoTrilha.SetActive(false);
        Rb = GetComponent<Rigidbody>();

    }

    public void AtivarTrilha()
    {
        objetoTrilha.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ParaRotacao()
    {
        Rb.velocity = new Vector3(0,0,0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Fora")
        {
            player.VoltaBola();
        }
    }

}
