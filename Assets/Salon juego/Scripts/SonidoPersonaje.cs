using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SonidoPersonaje : NetworkBehaviour {
    public float volumen;
    public Sonidos sonidosServidor;
    public Sonidos sonidosCliente;

    private Sonidos sonidosLocales;

    void Start()
    {
        if (isServer)
            sonidosLocales = isLocalPlayer ? sonidosServidor : sonidosCliente;
        else sonidosLocales = isLocalPlayer ? sonidosCliente : sonidosServidor;
    }

    void Update ()
    {
        if (isLocalPlayer)
        {
            string sonido = GetInputSonido();
            if (!string.IsNullOrEmpty(sonido))
                CmdReproducirSonido(sonido);
        }
	}

    [Command]
    private void CmdReproducirSonido(string sonido) { RpcReproducirSonido(sonido); }
    [ClientRpc]
    private void RpcReproducirSonido(string sonido)
    {
        AudioClip sonidoElegido = null;
        switch (sonido)
        {
            case "ven"       : sonidoElegido = sonidosLocales.ven;        break;
            case "alto"      : sonidoElegido = sonidosLocales.alto;       break;
            case "aqui"      : sonidoElegido = sonidosLocales.aqui;       break;
            case "ahora"     : sonidoElegido = sonidosLocales.ahora;      break;
            case "vamos"     : sonidoElegido = sonidosLocales.vamos;      break;
            case "genial"    : sonidoElegido = sonidosLocales.genial;     break;
            case "tututu"    : sonidoElegido = sonidosLocales.tututu;     break;
            case "cuidado"   : sonidoElegido = sonidosLocales.cuidado;    break;
            case "porPoco"   : sonidoElegido = sonidosLocales.porPoco;    break;
            case "perdida1"  : sonidoElegido = sonidosLocales.perdida1;   break;
            case "perdida2"  : sonidoElegido = sonidosLocales.perdida2;   break;
            case "perdida3"  : sonidoElegido = sonidosLocales.perdida3;   break;
            case "retrocede" : sonidoElegido = sonidosLocales.retrocede;  break;
            case "unodostres": sonidoElegido = sonidosLocales.unodostres; break;
        }
        AudioSource.PlayClipAtPoint(sonidoElegido, transform.position, volumen);
    }


    private string GetInputSonido()
    {
        if (Input.GetButtonDown("sonido ven"       )) return "ven"       ;
        if (Input.GetButtonDown("sonido alto"      )) return "alto"      ;
        if (Input.GetButtonDown("sonido aqui"      )) return "aqui"      ;
        if (Input.GetButtonDown("sonido ahora"     )) return "ahora"     ;
        if (Input.GetButtonDown("sonido vamos"     )) return "vamos"     ;
        if (Input.GetButtonDown("sonido genial"    )) return "genial"    ;
        if (Input.GetButtonDown("sonido tututu"    )) return "tututu"    ;
        if (Input.GetButtonDown("sonido cuidado"   )) return "cuidado"   ;
        if (Input.GetButtonDown("sonido porPoco"   )) return "porPoco"   ;
        if (Input.GetButtonDown("sonido retrocede" )) return "retrocede" ;
        if (Input.GetButtonDown("sonido unodostres")) return "unodostres";
        return "";
    }
}
