using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*******************************************
* FICHIER CODE PAR BAPTISTE
********************************************/

/********************************************
 Fonctions qui permettent de faire apparaitre  
 les ennemis aléatoirement
********************************************/
public class spawnBalls : MonoBehaviour
{
    public int nbrBallsDepart = 10,pauseint=0;
    public float intervalle = 11f;
    public GameObject model, Ennemi;

    public GameObject ennemi;
    public GameObject[] ennemis;

    void Start()
    {
        pauseint = PlayerPrefs.GetInt("pauseGUI");
    }

    void Update()
    {
        pauseint = PlayerPrefs.GetInt("pauseGUI");
        if(pauseint==1)
        {
            compter();
            if (this.nbrBallsDepart != 7)
            {
                creerNouvelleBoule();
                nbrBallsDepart++;
            }
        }
       
    }

    public int getNbrBallsDepart()
    {
        return nbrBallsDepart;
    }

    void compter()
    {
        nbrBallsDepart = 0;
        ennemis = GameObject.FindGameObjectsWithTag("ennemi");
        nbrBallsDepart = ennemis.Length;
    }

    void creerNouvelleBoule()
    {
        int decalage = Random.Range(-1, 1);
        float xAlea = Random.Range(-intervalle, intervalle) + decalage;
        if (xAlea >= intervalle)
        {
            xAlea = intervalle;
        }
        else if (xAlea <= -intervalle)
        {
            xAlea = -intervalle;
        }
        float y = 0.5f;
        float z = Random.Range(-2, 11);
        Vector3 position = new Vector3(xAlea, y, z);
        Ennemi = Instantiate(model, position, Quaternion.identity);
    }


}
