using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MedidorForca : MonoBehaviour
{
    public Slider slider;
    Player player;

    void Start()
    {
        player = FindObjectOfType<Player>(); 
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = player.forcaArremesso;
    }
}
