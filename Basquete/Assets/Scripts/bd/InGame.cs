using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using System;

public class InGame : MonoBehaviour
{
    private string url = "https://fh-portfolio.000webhostapp.com/banco/Basquete";
    Areapontuacao points;
    public TextMeshProUGUI suaPontuacao;
    public InputField nome;

    int pontos1, pontos2, pontos3, pontosAtuais;
    string nome1, nome2, nome3;

    void Start()
    {
        points = FindObjectOfType<Areapontuacao>();
        StartCoroutine(WebCarregar());  
    }

    void Update()
    {
        pontosAtuais = points.pontos;
        suaPontuacao.GetComponent<TextMeshProUGUI>().text = "Seus Pontos: " + pontosAtuais;
    }

    IEnumerator WebDeletar()
    {
        UnityWebRequest www = UnityWebRequest.Get(url + "/limpar.php");
        yield return www.SendWebRequest();
        if (www.isHttpError)
        {
            Debug.Log("Deu Ruim: " + www.error);
        }
        else
        {
            Debug.Log("Deu bom: " + www.downloadHandler.text);
        }
    }

    IEnumerator WebInserir()
    {
        WWWForm form = new WWWForm();
        form.AddField("nome1", nome1);
        form.AddField("pontos1", pontos1);
        form.AddField("nome2", nome2);
        form.AddField("pontos2", pontos2);
        form.AddField("nome3", nome3);
        form.AddField("pontos3", pontos3);
        Debug.Log("valores sendo eviados: " + nome1 + pontos1 + " " + nome2 + pontos2 + " " + nome3 + pontos3);
        using (UnityWebRequest www = UnityWebRequest.Post(url + "/cadastrar.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log("Deu Ruim: " + www.error);
            }
            else
            {
                Debug.Log("Deu Bom: ");
            }
        }
        SceneManager.LoadScene("MenuInicio");
    }

    IEnumerator WebCarregar()
    {
        UnityWebRequest www = UnityWebRequest.Get(url + "/consultar.php");
        yield return www.SendWebRequest();
        if (www.isHttpError)
        {
            Debug.Log("Deu Ruim: " + www.error);
        }
        else
        {
            string placar = www.downloadHandler.text;
            string[] lugares = placar.Split(';');
            string[] lugar1 = lugares[0].Split('-');
            string[] lugar2 = lugares[1].Split('-');
            string[] lugar3 = lugares[2].Split('-');
            nome1 = lugar1[0];
            pontos1 = int.Parse(lugar1[1]);
            nome2 = lugar2[0];
            pontos2 = int.Parse(lugar2[1]);
            nome3 = lugar3[0];
            pontos3 = int.Parse(lugar3[1]);
            Debug.Log(nome1+pontos1+" "+ nome2 + pontos2 + " "+ nome3 + pontos3);
        }
    }

    void MontaListaCampeoes()
    {
        if (nome.text == "")
        {
            nome.text = "Indefinido";
        }

        if (pontosAtuais > pontos1)
        {
            pontos3 = pontos2;
            pontos2 = pontos1;
            pontos1 = pontosAtuais;

            nome3 = nome2;
            nome2 = nome1;
            nome1 = nome.text;
        }
        else if (pontosAtuais > pontos2)
        {
            pontos3 = pontos2;
            pontos2 = pontosAtuais;

            nome3 = nome2;
            nome2 = nome.text;
        }
        else if (pontosAtuais > pontos3)
        {
            pontos3 = pontosAtuais;
            nome3 = nome.text;
        }
        pontosAtuais = 0;
        nome.text = "";
        StartCoroutine(WebInserir());
        
    }

    public void Sair()
    {
        MontaListaCampeoes();
    }
}
