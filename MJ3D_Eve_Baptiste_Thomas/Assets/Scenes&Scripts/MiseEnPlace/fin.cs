using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*******************************************
* FICHIER CODE PAR THOMAS
********************************************/
public class fin : MonoBehaviour
{
    public void choix() 
	{
		SceneManager.LoadScene("Choix_niveaux");
	}

	public void Quitter()
	{
		Application.Quit();
	}
}
