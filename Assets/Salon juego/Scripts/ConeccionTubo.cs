using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeccionTubo : MonoBehaviour
{
    public bool conectado;
    public bool personajeAlLado;

    public MovimientoPersonaje personajeAdjacente = null;

    void OnTriggerEnter2D(Collider2D theCollision)
    {
        if (theCollision.gameObject.tag == "Player")
        {
            personajeAlLado = true;
            personajeAdjacente = theCollision.GetComponent<MovimientoPersonaje>();
            conectado = personajeAdjacente.quieto;
        }
    }

    private void Update()
    {
        if (personajeAlLado && !conectado)
            conectado = personajeAdjacente.quieto;
    }

    void OnTriggerExit2D(Collider2D theCollision)
    {
        if (theCollision.gameObject.tag == "Player")
        {
            conectado = false;
            personajeAlLado = false;
            personajeAdjacente = null;
        }
    }
}