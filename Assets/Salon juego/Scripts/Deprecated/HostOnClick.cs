using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class HostOnClick : MonoBehaviour
{

    public void Host()
    {
        NetworkLobbyManager.singleton.StartHost();
        //NetworkManager.singleton.StartHost();
    }
}
