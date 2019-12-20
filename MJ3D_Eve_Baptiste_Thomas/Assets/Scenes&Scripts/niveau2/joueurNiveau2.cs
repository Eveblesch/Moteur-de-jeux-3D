using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

/*******************************************
* FICHIER CODE PAR BAPTISTE
********************************************/
public class joueurNiveau2 : MonoBehaviour
{
    public commun affichages_communs;
    public float puissanceSaut = 2.0f;
    public Vector3 saut;
    public AudioSource laPiste;
    public AudioClip sonSaut,sonMort;

    private void Start()
    {
        saut = new Vector3(0.0f, 4.0f, 0.0f);
        laPiste = GetComponent<AudioSource>();
    }

    void Update()
    {

        if (affichages_communs.pause==0)
        {
            //deplacements latéraux
            transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * affichages_communs.vitesse_directionnelle, 0f, Input.GetAxis("Vertical") * Time.deltaTime * affichages_communs.vitesse_directionnelle);
            
            //saut
            if (Input.GetButtonDown("Jump") && SurLeSol())
            {
                transform.Rotate(0, 0, 0);
                GetComponent<Rigidbody>().velocity = new Vector3(0f, 9f, 0f);
                affichages_communs.instructionText.text = "";
                laPiste.clip = sonSaut;
                laPiste.Play();
            }
            //chute
            if (transform.position.y < -6)
            {
                laPiste.clip = sonMort;
                laPiste.Play();
                affichages_communs.instructionText.text = "";
                affichages_communs.perteVie();
                transform.position = new Vector3(0, 2, 0);
            }
        }
        
    }

/********************************************************
* Fonction qui gère la collision du joueur avec les pièces
* et l'incrémentation du score
*********************************************************/

    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag == "Piece")
        {
            affichages_communs.colPiece();
        }
    }

/********************************************************
* Fonction qui gère la fin du jeu à l'arrivée (affichages)
*********************************************************/
    void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.name == "MurInvisible")
        {
            StartCoroutine(affichages_communs.victoire());
        }
    }

    private bool SurLeSol()
    {
        int layerMask = LayerMask.GetMask("Ground");

        if (Physics.CheckSphere(transform.position, GetComponent<SphereCollider>().radius + 0.01f, layerMask: layerMask))
        {
            return true;
        }
        return false;
    }
}
