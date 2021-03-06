﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegarsePersonaje : MonoBehaviour {
    public ConeccionTubo conectionUp;
    public ConeccionTubo conectionDown;
    public ConeccionTubo conectionLeft;
    public ConeccionTubo conectionRight;

    void Update()
    {
        int playerCant = 0;
        int playerMoviendo = 0;
        
        Vector2 movimiento = new Vector2(0,0);
        ConeccionTubo[] conecciones = { conectionUp, conectionDown, conectionLeft, conectionRight };
        List<MovimientoPersonaje> personjesProcesados = new List<MovimientoPersonaje>();
        foreach (ConeccionTubo coneccion in conecciones)
        {
            bool coneccionConectada = coneccion.conectado;
            bool pjYaProcesado = personjesProcesados.Contains(coneccion.personajeAdjacente);

            if (coneccionConectada && !pjYaProcesado && !coneccion.personajeAdjacente.quieto)
            {
                playerCant++;
                playerMoviendo += coneccion.personajeAdjacente.quieto ? 0 : 1;
                //Vector2 pjDestino = coneccion.personajeAdjacente.posicionDestino;
                Vector2 pjPosicion = coneccion.personajeAdjacente.transform.position;
                Vector2 coneccionOffset = coneccion.transform.localPosition;

                movimiento += pjPosicion + coneccionOffset;
            }
        }

        if (playerCant == 2)
        {
            if (playerMoviendo == 2)
            {
                transform.position = movimiento / 2;
            }
            else Alinearse();
        }
        else Alinearse();
    }

    private void Alinearse()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Round(pos.x);
        pos.y = Mathf.Round(pos.y + .5f) - 0.5f;
        pos.z = Mathf.Round(pos.z);

        transform.position = pos;
    }
}
