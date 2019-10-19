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
    bool checa = true;
    float timer = 0f;

    private void Start()
    {
        efeitoBola.SetActive(false);
        controller = GetComponent<GameController>();
    }

    private void Update()
    {
        pontosText.text = "PONTOS: " + pontos.ToString();

        if (checa == false)
        {
            timer += Time.deltaTime;
            if (timer  >= 2)
            {
                timer = 0f;
                checa = true;
            }
        }
    }


    void OnTriggerEnter(Collider outroCollider)
    {
        if (checa)
        {
            if (outroCollider.GetComponent<Bola>())
            {
                efeitoBola.SetActive(true);
                pontos++;
                checa = false;
            }
        }
       
    }
}
