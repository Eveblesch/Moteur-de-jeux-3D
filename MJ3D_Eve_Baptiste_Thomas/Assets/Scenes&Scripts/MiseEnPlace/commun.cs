using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

/*******************************************************
* Fonctions d'affichages (Score, Vie, Victoire, Défaite)
*******************************************************/
/****************************************************
*	FICHIER CODE PAR EVE
*****************************************************/
public class commun : MonoBehaviour
{
   //public Text scoreText, vieText;
	public Text scoreText, defaiteText, victoireText, vieText,instructionText;
	public int score = 0, vie = 3, pause=0, debut=0;
	public int vitesse_directionnelle = 7;
	public int vitesse_avancement = 5;
    public AudioSource laPiste;
    public AudioClip sonCoin,sonObstacle,sonVictoire,sonDefaite;
    public bool mute;

    public void Start()
    {
        laPiste = GetComponent<AudioSource>();
        mute = true;
    }
    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }
    public void AffichageScore(int sc)
    {
        scoreText.text = "Score : " + sc.ToString();
    }

    public void AffichageVie(int nb)
    {
        vieText.text = "Vie : " + nb.ToString();
    }

  

    public void perteVie()
    {
        laPiste.PlayOneShot(sonObstacle);
        vie--;
        AffichageVie(vie);
        if (vie == 0)
        {
            score = 0;
            StartCoroutine(defaite());
        }
    }

    public void colPiece()
    {
        laPiste.PlayOneShot(sonCoin);
    	score += 50;
        AffichageScore(score);
    }

    public IEnumerator defaite()
    {
        laPiste.PlayOneShot(sonDefaite);
        pause = 1;
        defaiteText.text = "DEFAITE";
        yield return new WaitForSeconds(2);
        defaiteText.text = "";

        AffichageVie(vie);
        PlayerPrefs.SetString ("derniereScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("retry");

        pause = 0;
        vie = 3;
        debut = 0;
    }

    public IEnumerator victoire()
    {
        laPiste.PlayOneShot(sonVictoire);
        pause = 1;
        victoireText.text = "VICTOIRE";
        yield return new WaitForSeconds(2);
        victoireText.text = "";
        
        string scene = SceneManager.GetActiveScene().name;
        switch(scene)
        {
        	case "niveau1_facile":
        		SceneManager.LoadScene("niveau2_facile");
        		break;
        	case "niveau1_moyen":
        		SceneManager.LoadScene("niveau2_moyen");
        		break;
        	case "niveau1_difficile":
        		SceneManager.LoadScene("niveau2_difficile");
        		break;
        	case "niveau2_facile":
        		SceneManager.LoadScene("niveau3");
        		break;
        	case "niveau2_moyen":
        		SceneManager.LoadScene("niveau3");
        		break;
        	case "niveau2_difficile":
        		SceneManager.LoadScene("niveau3");
        		break;
        	case "niveau3":
        		SceneManager.LoadScene("niveau4");
        		break;
        	case "niveau4":
        		SceneManager.LoadScene("fin");
        		break;
        }
        pause = 0;
    }
    void OnGUI()
    {
        if (GUI.Button(new Rect(1700, 20, 100, 50), "Mute"))
        {
            if (mute)
            {
                AudioListener.pause = true;
                mute = false;
            }
            else
            {
                AudioListener.pause = false;
                mute = true;
            }
        }
    }
}
