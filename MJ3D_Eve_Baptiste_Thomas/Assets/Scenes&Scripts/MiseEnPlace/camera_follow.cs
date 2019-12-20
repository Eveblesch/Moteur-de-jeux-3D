using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*******************************************
* FICHIER CODE PAR EVE
********************************************/

/***************************************************
* Fonction qui fait suivre le joueur par la caméra
***************************************************/

public class camera_follow : MonoBehaviour
{
	public GameObject joueur;        

    private Vector3 offset;           

    void Start () 
    {
        offset = transform.position - joueur.transform.position;
    }

    void Update () 
    {
        transform.position = joueur.transform.position + offset;
    }
}
