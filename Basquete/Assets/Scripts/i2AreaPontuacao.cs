using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class i2AreaPontuacao : MonoBehaviour
{
    public GameObject efeitoBola;
    public GameObject block2;
    Areapontuacao controller;
    bool checa = true, blocked = true;
    float timer = 0f;

    private void Start()
    {
        efeitoBola.SetActive(false);
        controller = FindObjectOfType<Areapontuacao>();
    }

    private void Update()
    {

        if (checa == false)
        {
            timer += Time.deltaTime;
            if (timer >= 2)
            {
                blocked = true;
                timer = 0f;
                checa = true;
            }
        }

        if (blocked)
        {
            block2.SetActive(true);
        }
        else
        {
            block2.SetActive(false);
        }
    }


    void OnTriggerEnter(Collider outroCollider)
    {
        if (checa)
        {
            if (outroCollider.gameObject.tag == "Bola")
            {
                blocked = false;
                efeitoBola.SetActive(true);
                controller.pontos++;
                checa = false;
            }
        }

    }
}
