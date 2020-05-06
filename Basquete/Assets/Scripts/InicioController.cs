using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using TMPro;

public class InicioController : MonoBehaviour
{
    private string url = "https://fh-portfolio.000webhostapp.com/banco/Basquete";
    public TextMeshProUGUI texto;
    public GameObject painel;
    int pontos1, pontos2, pontos3;
    string nome1, nome2, nome3;

    public void AbreCreditos()
    {
        painel.SetActive(true);
    }

    public void FechaCreditos()
    {
        painel.SetActive(false);
    }

    public void Sair()
    {
        Application.Quit();
    }

    public void Game()
    {
        SceneManager.LoadScene("LevelLoader");
    }

    public void Inicio()
    {
        SceneManager.LoadScene("MenuInicio");
    }

    void Start()
    {
        painel.SetActive(false);
        Time.timeScale = 1;
        StartCoroutine(WebCarregar());
    }

    private void CarregarRanking()
    {
        texto.GetComponent<TextMeshProUGUI>().text = "1º " + nome1;
        texto.GetComponent<TextMeshProUGUI>().text += "- " + pontos1 + "\n";

        texto.GetComponent<TextMeshProUGUI>().text += "2º " + nome2;
        texto.GetComponent<TextMeshProUGUI>().text += "- " + pontos2 + "\n";

        texto.GetComponent<TextMeshProUGUI>().text += "3º " + nome3;
        texto.GetComponent<TextMeshProUGUI>().text += "- " + pontos3;
    }


    public void Carregar()
    {
        StartCoroutine(WebCarregar());
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
        }
        CarregarRanking();
    }
}
