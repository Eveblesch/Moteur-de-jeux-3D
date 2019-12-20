using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/*******************************************
* FICHIER CODE PAR BAPTISTE
********************************************/

public class piece : MonoBehaviour
{
	/************************************************
	* Fonction qui cache les pièces lorsqu'il y a une
	* collision avec le joueur
	************************************************/
    void OnTriggerEnter(Collider obj)
    {
		if(obj.gameObject.name=="joueur")
        {
            this.gameObject.SetActive(false);

        }
    }

}
