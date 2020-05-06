using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI tempo;
    public GameObject painelFim;
    Player player;
    public float timer = 100f;
    float segundos;
    float minutos;

    private void Start()
    {
        painelFim.SetActive(false);
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        string minutes = Mathf.Floor(timer / 60).ToString("00");
        string seconds = (timer % 60).ToString("00");

        tempo.GetComponent<TextMeshProUGUI>().text = string.Format("{0}:{1}", minutes, seconds); 

        if (timer <= 0)
        {
            Destroy(player);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
            painelFim.SetActive(true);
        }
    }

}
