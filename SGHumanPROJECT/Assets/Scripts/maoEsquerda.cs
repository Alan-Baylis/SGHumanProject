﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class maoEsquerda : MonoBehaviour {

	[Header("Color")]
	public Color startColor;
	public Color hoverColor;

	[Header("Texto")]
	public Text headerText;
	public Text resumoTexto;

	[Header("Pivo")]
	public Transform partToRotate;

	[Header("Outros")]
	public bool quadro;

	// variaveis 

	private string texto;
	private string textoTitulo;
	private Renderer rend;

	// Awake
	void Awake(){
		quadro = false;
		rend = GetComponent<Renderer> ();
		startColor = rend.material.color;

		textoTitulo = "Ossos das Mão";
		texto = "\n" + "\n" + "A mão divide-se em: carpo, metacarpo e falanges.";
	}

	void OnMouseDown(){
		if (!quadro) {
			resumoTexto.text = texto;
			headerText.text = textoTitulo;
			rend.material.color = startColor;
			GameMaster.clone = partToRotate.gameObject;
			CameraMovement.gameObjectName = "maoEsquerda";
			CameraMovement.escolhido = true;
		}
	}

	void OnMouseEnter(){
		if (!quadro) {
			rend.material.color = hoverColor;
		}
	}

	void OnMouseExit(){
		if (!quadro) {
			rend.material.color = startColor;
		}
	}

	void Update(){
		if (quadro) {
			int speed = 100;
			partToRotate.transform.Rotate (Vector3.up * speed * Time.deltaTime);
		}
	}
}
