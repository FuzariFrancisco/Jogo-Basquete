using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaoDestroiObjeto : MonoBehaviour
{
    private static NaoDestroiObjeto musicaInstance;

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (musicaInstance == null)
        {
            musicaInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
