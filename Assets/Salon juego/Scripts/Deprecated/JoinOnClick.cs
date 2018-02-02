using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class JoinOnClick : MonoBehaviour
{
    public GameObject lobbyScreen;
    public GameObject joinScreen;

    private bool pressedJoin = false;
    public void Awake()
    {
        pressedJoin = false;
    }

    public void Join()
    {
        NetworkLobbyManager.singleton.StartClient();
        pressedJoin = true;
        //NetworkManager.singleton.StartClient();
    }

    public void Update()
    {
        if (pressedJoin && NetworkLobbyManager.singleton.IsClientConnected())
        {
            joinScreen.SetActive(false);
            lobbyScreen.SetActive(true);
        }

    }
}
