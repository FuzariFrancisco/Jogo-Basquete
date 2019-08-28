using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Player player;
    public Text tempo;

    public float Timer = 100f;

    void Update()
    {
        Timer -= Time.deltaTime;
        tempo.text = "TEMPO: " + Mathf.Floor(Timer);
    }

}
