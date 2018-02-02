using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;
using UnityEngine.UI;

public class ReadyButton : MonoBehaviour
{
    public Button button;
    public Color readyColor;
    public Color waitingColor;

    public void ChangeReady()
    {
        NetworkLobbyPlayer[] Jugadores = GameObject.FindObjectsOfType<NetworkLobbyPlayer>();
        foreach (NetworkLobbyPlayer player in Jugadores)
        {
            if (player.isLocalPlayer)
            {
                player.readyToBegin = !player.readyToBegin;

                if (player.readyToBegin)
                    player.SendReadyToBeginMessage();
                else player.SendNotReadyToBeginMessage();

                ReadyColor(player.readyToBegin);
            }
        }
    }
    public void ReadyColor(bool ready)
    {
         ColorBlock cb = button.colors;
        cb.normalColor = ready ? readyColor : waitingColor;
        cb.disabledColor = ready ? readyColor : waitingColor;
        cb.highlightedColor = ready ? readyColor : waitingColor;
        cb.pressedColor = ready ? waitingColor : readyColor;
        button.colors = cb;
    }
 }
