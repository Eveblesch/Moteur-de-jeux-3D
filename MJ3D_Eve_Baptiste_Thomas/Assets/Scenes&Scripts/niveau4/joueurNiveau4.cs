using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

/*******************************************
* FICHIER CODE PAR EVE & BAPTISTE & THOMAS
********************************************/
public class joueurNiveau4 : MonoBehaviour
{
    public commun affichages_communs;


    public int vitesse_directionnelle = 4, vie = 3, pauseint = 0,nbrBallsKill=0,score=0;
    public Text killText;
    public AudioSource laPiste;
    public AudioClip sonMissile, sonVictoire, sonDefaite;

    // Update is called once per frame
    void Start()
    {
        affichages_communs.victoireText.text = "";
        affichages_communs.defaiteText.text = "";

        PlayerPrefs.SetInt("vieGUI",vie);
        PlayerPrefs.SetInt("scoreGUI", score);
        PlayerPrefs.SetInt("pauseGUI", 1);
        PlayerPrefs.SetInt("debutGUI", 1);
        PlayerPrefs.SetInt("nbrBallsKillGUI", nbrBallsKill);

        laPiste = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            laPiste.clip = sonMissile;
            laPiste.Play();
        }

        if (transform.position.x <= -10)
        {
            transform.position = new Vector3(-10, transform.position.y, transform.position.z);
        }

        if (transform.position.x >= 10)
        {
            transform.position = new Vector3(10, transform.position.y, transform.position.z);
        }

        if (affichages_communs.debut==0 && Input.GetButtonDown("Vertical"))
        {
            affichages_communs.instructionText.text = "";
            PlayerPrefs.SetInt("debutGUI", 2);

            affichages_communs.debut = 1;
            
        } 

        if(affichages_communs.pause==0 && affichages_communs.debut==1)
        {
            transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * affichages_communs.vitesse_directionnelle, 0f, 0f);
            vie = PlayerPrefs.GetInt("vieGUI");
            nbrBallsKill = PlayerPrefs.GetInt("nbrBallsKillGUI");
            score = PlayerPrefs.GetInt("scoreGUI");
            affichages_communs.AffichageScore(score);
            AffichageKill(nbrBallsKill);
            affichages_communs.AffichageVie(vie);

            if(nbrBallsKill >= 20)
            {
                laPiste.clip = sonVictoire;
                laPiste.Play();
                StartCoroutine(victoire());
            }
            else if (vie <= 0)
            {
                laPiste.clip = sonDefaite;
                laPiste.Play();
                StartCoroutine(defaite());
            }
        }
        else
        {
            PlayerPrefs.SetInt("vieGUI", vie);
        }
    }

    void AffichageKill(int nb)
    {
        killText.text = "Kill : " + nb.ToString();
    }
  
    IEnumerator defaite()
    {
        PlayerPrefs.SetInt("debutGUI", 1);
        affichages_communs.debut= 0;
        PlayerPrefs.SetInt("pauseGUI", 2);
        affichages_communs.pause = 1;

        //Suppression de tous les ennemis restants
        GameObject[] deadItems = GameObject.FindGameObjectsWithTag("ennemi");
        foreach (GameObject deadItem in deadItems)
            Destroy(deadItem);

        //Suppression de tous les missiles restants
        deadItems = GameObject.FindGameObjectsWithTag("missile");
        foreach (GameObject deadItem in deadItems)
            Destroy(deadItem);

        affichages_communs.defaiteText.text = "DEFAITE";
        yield return new WaitForSeconds(2);
        affichages_communs.defaiteText.text = "";
        
        vie = 3;
        nbrBallsKill = 0;
        score = 0;

        AffichageKill(nbrBallsKill);
        affichages_communs.AffichageVie(vie);

        PlayerPrefs.SetInt("vieGUI", vie);
        PlayerPrefs.SetInt("nbrBallsKillGUI", nbrBallsKill);
        PlayerPrefs.SetInt("pauseGUI", 1);
        PlayerPrefs.SetInt("scoreGUI",score);

        affichages_communs.pause = 0;
        PlayerPrefs.SetString ("derniereScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Retry");
    }
    

    IEnumerator victoire()
    {
        affichages_communs.pause = 1;
        PlayerPrefs.SetInt("pauseGUI", 2);
        
        //Suppression de tous les ennemis restants
        GameObject[] deadItems = GameObject.FindGameObjectsWithTag("ennemi");
        foreach (GameObject deadItem in deadItems)
            Destroy(deadItem);

        //Suppression de tous les missiles restants
        deadItems = GameObject.FindGameObjectsWithTag("missile");
        foreach (GameObject deadItem in deadItems)
            Destroy(deadItem);

        affichages_communs.victoireText.text = "VICTOIRE";
        yield return new WaitForSeconds(2);
        affichages_communs.victoireText.text = "";

        vie = 3;
        nbrBallsKill = 0;
        score = 0;

        PlayerPrefs.SetInt("vieGUI", vie);
        PlayerPrefs.SetInt("nbrBallsKillGUI", nbrBallsKill);
        PlayerPrefs.SetInt("scoreGUI", score);
        PlayerPrefs.SetInt("pauseGUI", 1);
        affichages_communs.pause = 0;
        SceneManager.LoadScene("fin");

    }
}
