using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    public GameObject objetoTrilha;
    // Start is called before the first frame update
    void Start()
    {
        objetoTrilha.SetActive(false);

    }

    public void AtivarTrilha()
    {
        objetoTrilha.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
