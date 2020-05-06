using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Areapontuacao : MonoBehaviour
{
    public GameObject efeitoBola;
    public TextMeshProUGUI pontosText;
    public GameObject block1;
    public int pontos = 0;
    GameController controller;
    bool checa = true, blocked = true;
    float timer = 0f;

    private void Start()
    {
        efeitoBola.SetActive(false);
        controller = FindObjectOfType<GameController>();
    }

    private void Update()
    {
        pontosText.GetComponent<TextMeshProUGUI>().text = "PONTOS: " + pontos.ToString();

        if (checa == false)
        {
            timer += Time.deltaTime;
            if (timer  >= 2)
            {
                blocked = true;
                timer = 0f;
                checa = true;
            }
        }

        if (blocked)
        {
            block1.SetActive(true);
        }
        else
        {
            block1.SetActive(false);
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
                pontos++;
                checa = false;
            }
        }
       
    }
}
