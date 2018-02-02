using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class DisconnectOnClick : MonoBehaviour
{

    public void Disconnect()
    {
        NetworkLobbyManager.singleton.StopHost();
    }
}
