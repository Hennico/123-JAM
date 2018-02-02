using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class JoinOnClick : MonoBehaviour
{

    public void Join()
    {
        NetworkLobbyManager.singleton.StartClient();
        //NetworkManager.singleton.StartClient();
    }
}
