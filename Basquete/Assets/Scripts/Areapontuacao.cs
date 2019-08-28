using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Areapontuacao : MonoBehaviour
{
    public GameObject efeitoBola;
    public Text pontosText;
    int pontos = 0;
    GameController controller;

    private void Start()
    {
        efeitoBola.SetActive(false);
        controller = GetComponent<GameController>();
    }

    private void Update()
    {
        pontosText.text = "PONTOS: " + pontos.ToString();
    }


    void OnTriggerEnter(Collider outroCollider)
    {
       if (outroCollider.GetComponent<Bola>())
        {
            efeitoBola.SetActive(true);
            pontos++;
        }
    }
}
