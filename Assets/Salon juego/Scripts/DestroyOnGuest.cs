using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DestroyOnGuest : NetworkBehaviour
{
    public GameObject server;
    public GameObject cliente;

    void Start()
    {
        if (isServer)
        {
            DestroyObject(cliente);
        }
        else
        {
            DestroyObject(server);
        }
    }
}