using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class SeleccionadorDeSonido : NetworkBehaviour {


	public Queue<int> cola = new Queue<int>();
	public Sonidos serverSound;
	public Sonidos clienteSound;
	public ColaScript sonidos;
	private int nuevoSonido = 0;
	Sonidos asd;


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		asd = isServer?serverSound:clienteSound;

		if (Input.GetKeyDown ("q")) {
			nuevoSonido = asd.Codigoalto;
		} else if (Input.GetKeyDown ("w")) {
			nuevoSonido = asd.Codigocuidado;
		} else if (Input.GetKeyDown ("e")) {
			nuevoSonido = asd.Codigoretrocede;
		} else if (Input.GetKeyDown ("r")) {
			nuevoSonido = asd.Codigoaqui;
		} else if (Input.GetKeyDown ("t")) {
			nuevoSonido = asd.Codigounodostres;
		} else if (Input.GetKeyDown ("a")) {
			nuevoSonido = asd.Codigogenial;
		} else if (Input.GetKeyDown ("s")) {
			nuevoSonido = asd.Codigoven;
		} else if (Input.GetKeyDown ("d")) {
			nuevoSonido = asd.CodigoporPoco;
		} else if (Input.GetKeyDown ("f")) {
			nuevoSonido = asd.Codigovamos;
		} else if (Input.GetKeyDown ("p")) {
			nuevoSonido = asd.Codigotututu;
		}
		//ordenar al server
		if (nuevoSonido != 0){
			CmdagregarSonidoEnCola(nuevoSonido);
			nuevoSonido = 0;
		}
		if (cola.Count > 0) {
			//NetworkServer.Spawn (new ColaScript(cola.Dequeue()));
			//Debug.Log(cola.Peek());
			sonidos.codigo = cola.Peek();
			sonidos.reproducir ();
			cola.Dequeue ();
		}
	}

	[Command]
	public void CmdagregarSonidoEnCola(int codigo)
	{
		cola.Enqueue(codigo);
	}
}
