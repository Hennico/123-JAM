using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EsperarInvitado : NetworkBehaviour {
    GameObject playerPrefab;
    List<NetworkPlayer> jugadoresPendientes;
    
    //private void OnPlayerConnected(NetworkPlayer player)
    //{
    //    jugadoresPendientes.Add(player);
    //}
    //
    //private void Update()
    //{
    //    if (jugadoresPendientes.Count == 2)
    //    {
    //        foreach (NetworkPlayer jugador in jugadoresPendientes)
    //        {
    //            NetworkServer.AddPlayerForConnection()
    //        }
    //    }
    //
    //}

}
