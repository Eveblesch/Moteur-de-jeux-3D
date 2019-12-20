using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

/*******************************************
* FICHIER CODE PAR EVE
********************************************/
public class ennemisNiveau4 : MonoBehaviour
{

    public int vitesse_directionnelle = 4, viesrestantes = 3, nbrBallsKill = 0, score=0, vies = 0, vitesse_avancement = 3, debut=1;

    void Start()
    {
        debut= PlayerPrefs.GetInt("debutGUI");
    }

    void Update()
    {
        debut= PlayerPrefs.GetInt("debutGUI");
        if(debut==2)
        {
            vies = PlayerPrefs.GetInt("vieGUI");
            transform.position -= Vector3.forward * Time.deltaTime * vitesse_avancement;

            if (transform.position.x <= -11)
            {
                transform.position = new Vector3(transform.position.x+1, transform.position.y,transform.position.z);
            }

            if (transform.position.x >= 11)
            {
                transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            }
        }  
    }

    public int getViesRestantes()
    {
        return viesrestantes;
    }

    void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.tag == "missile")
        {
            nbrBallsKill = PlayerPrefs.GetInt("nbrBallsKillGUI");
            PlayerPrefs.SetInt("nbrBallsKillGUI", nbrBallsKill + 1);
            score = PlayerPrefs.GetInt("scoreGUI");
            PlayerPrefs.SetInt("scoreGUI", score + 10);
            Destroy(gameObject);
        }

        if (obj.gameObject.tag == "mortballe")
        {
            vies -= 1;
            PlayerPrefs.SetInt("vieGUI", vies);
            Destroy(gameObject);
        }
    }
}
