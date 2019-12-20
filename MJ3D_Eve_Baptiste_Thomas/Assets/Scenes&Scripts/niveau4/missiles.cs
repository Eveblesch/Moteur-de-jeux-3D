using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

/*******************************************
* FICHIER CODE PAR THOMAS
********************************************/

/***********************************************************
*Fonction qui permet de lancer les missiles et les détruire
************************************************************/
public class missiles : MonoBehaviour
{
    public GameObject projectile;
    public bool attente=false;
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && attente == false)
        {
            float x = transform.position.x;
            float y = transform.position.y;
            float z = transform.position.z+1;
            Vector3 position = new Vector3(x,y,z);
            GameObject Missile = Instantiate(projectile, position, Quaternion.identity);

            //Le détruire au bout de 4 secodnes (si jamais le missile touche personne)
            
            StartCoroutine(attendre());
            Destroy(Missile, 4);
        }
    }

    public IEnumerator attendre()
    {
        attente = true;
        yield return new WaitForSeconds(0.3f);
        attente = false;
    }
}
