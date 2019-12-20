using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*******************************************
* FICHIER CODE PAR THOMAS
********************************************/

/**************************************************************************************
* Fonctions qui permettent de choisir un niveau de difficulté + load la première scène
***************************************************************************************/
public class choixNiveau : MonoBehaviour
{

 	public void Jouer_facile() 
  	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void Jouer_moyen() 
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex + 2);
	}

	public void Jouer_difficile() 
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex + 3);
	}
	
}
