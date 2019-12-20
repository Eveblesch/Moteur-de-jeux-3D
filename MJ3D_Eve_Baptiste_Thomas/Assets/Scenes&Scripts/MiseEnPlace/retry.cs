using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*******************************************
* FICHIER CODE PAR THOMAS
********************************************/

/******************************************************************
* Fonctions qui permettent de rejouer, de passer au prochain niveau 
* ou de quitter le jeu
*******************************************************************/
public class retry : MonoBehaviour
{

	string scene;
	
	void Start()
    {
        scene= PlayerPrefs.GetString("derniereScene");
    }
	 
	public void Reessayer() 
	{

        switch(scene)
        {
            case "niveau1_facile":
                SceneManager.LoadScene("niveau1_facile");
                break;
            case "niveau1_moyen":
                SceneManager.LoadScene("niveau1_moyen");
                break;
            case "niveau1_difficile":
                SceneManager.LoadScene("niveau1_difficile");
                break;
            case "niveau2_facile":
                SceneManager.LoadScene("niveau2_facile");
                break;
            case "niveau2_moyen":
                SceneManager.LoadScene("niveau2_moyen");
                break;
            case "niveau2_difficile":
                SceneManager.LoadScene("niveau2_difficile");
                break;
            case "niveau3":
                SceneManager.LoadScene("niveau3");
                break;
            case "niveau4":
                SceneManager.LoadScene("niveau4");
                break;
        }
	}

	public void Passer()
	{
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
	}

	public void Quitter()
	{
		Application.Quit();
	}
}
