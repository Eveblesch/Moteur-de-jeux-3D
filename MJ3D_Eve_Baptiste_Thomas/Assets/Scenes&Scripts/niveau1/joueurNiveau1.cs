using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

/*******************************************
* FICHIER CODE PAR EVE
********************************************/

public class joueurNiveau1 : MonoBehaviour
{
    public commun affichages_communs;


    //Mouvements
    void Update()
    {
      
        if (transform.position.y <= -4)
        {
            transform.position = new Vector3(0, 1, -28);
            affichages_communs.perteVie();
        }
        //Démarrage
        else if (affichages_communs.debut == 0 && Input.GetButtonDown("Vertical"))
        {
            affichages_communs.debut = 1;
            affichages_communs.instructionText.text = "";
        }

        //Déplacements
        else if (affichages_communs.pause == 0 && affichages_communs.debut == 1)
        {
            transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * affichages_communs.vitesse_directionnelle, 0f, 0f);
            transform.position += Vector3.forward * Time.deltaTime * affichages_communs.vitesse_avancement;
        }

        else if (affichages_communs.pause == 1 && affichages_communs.vie > 0 && Input.GetButtonDown("Vertical"))
        { 
            affichages_communs.pause = 0;
        }
        
    }

/*************************************************************
* Fonction qui gère les collisions avec les obstacles
* (perte de vie, reset du score, retour au départ)
*************************************************************/
    void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.tag == "Obstacle")
        {
            transform.position = new Vector3(0, 1, -28);
            affichages_communs.AffichageScore(affichages_communs.score);
            GameObject[] tabPieces = GameObject.FindGameObjectsWithTag("Piece");
            foreach (GameObject i in tabPieces)
            {
                i.SetActive(true);
            }
            affichages_communs.perteVie();
        }
        affichages_communs.pause = 1;

        if (obj.gameObject.name == "MurInvisible")
        {
            StartCoroutine(affichages_communs.victoire());
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
}