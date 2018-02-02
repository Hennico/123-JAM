using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MovimientoPersonaje : NetworkBehaviour {
    public float velocidad = 2f;
    public Vector2 tamCelda;

    public Vector2 bordeIzquierdaAbajo;
    public Vector2 bordeDerechaArriba;

    private Animator anim;
    
    public bool quieto;
    public Vector3 posicionDestino;

    public RuntimeAnimatorController controllerServer;
    public RuntimeAnimatorController controllerClient;

    void Start()
    {
        posicionDestino = new Vector3(0, 0.5f, 0);
        anim = GetComponent<Animator>();

        if (isServer)
            anim.runtimeAnimatorController = isLocalPlayer ? controllerServer : controllerClient;
        else anim.runtimeAnimatorController = isLocalPlayer ? controllerClient : controllerServer;

    }

	void Update ()
    {
        if (isLocalPlayer && quieto)
        {
            Vector3 direccion = GetInputDirection();
            if (direccion.magnitude > 0)
                CmdAvanzar(direccion);
        }

        if (!quieto)
        {
            Vector3 animMovimiento = posicionDestino - transform.position;
            anim.SetFloat("MoveY", animMovimiento.y);
            anim.SetFloat("MoveX", animMovimiento.x);
        }
    }

    public void FixedUpdate()
    {
        quieto = posicionDestino.x == transform.position.x && posicionDestino.y == transform.position.y;
        if (!quieto)
        {
            float desplazamiento = velocidad * Time.fixedDeltaTime;
            Vector3 movimiento = posicionDestino - transform.position;

            if (movimiento.magnitude > desplazamiento)
                movimiento = movimiento.normalized * desplazamiento;

            transform.Translate(movimiento);
            quieto = posicionDestino.x == transform.position.x && posicionDestino.y == transform.position.y;
        }
        anim.SetBool("IsMoving", !quieto);
    }

    private Vector3 GetInputDirection()
    {
        if (Input.GetKeyDown("right"))
            return new Vector3(tamCelda.x, 0);
        if (Input.GetKeyDown("left"))
            return new Vector3(-tamCelda.x, 0);
        if (Input.GetKeyDown("up"))
            return new Vector3(0, tamCelda.y);
        if (Input.GetKeyDown("down"))
            return new Vector3(0, -tamCelda.y);

        return new Vector3(0, 0);
    }

    [Command]
    private void CmdAvanzar(Vector3 direccion) { RpcAvanzar(direccion); }
    [ClientRpc]
    private void RpcAvanzar(Vector3 direccion)
    {
        var xValido = (posicionDestino.x + direccion.x) < bordeDerechaArriba.x && (posicionDestino.x + direccion.x) > bordeIzquierdaAbajo.x;
        var yValido = (posicionDestino.y + direccion.y) < bordeDerechaArriba.y && (posicionDestino.y + direccion.y) > bordeIzquierdaAbajo.y;

        if (xValido && yValido)
            posicionDestino += direccion;
    }
}
