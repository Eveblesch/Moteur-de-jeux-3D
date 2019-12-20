using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

/*******************************************
* FICHIER CODE PAR BAPTISTE
********************************************/
public class moveMissile : MonoBehaviour
{
    public int vitesse = 10;

    void Update()
    {
        //Déplacement des missiles
        transform.position += transform.forward * (Time.deltaTime * vitesse);
    }

    void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
        if (obj.gameObject.tag == "ennemi")
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
        if (obj.gameObject.tag == "ennemi")
        {
            Destroy(gameObject);
        }
    }
}
