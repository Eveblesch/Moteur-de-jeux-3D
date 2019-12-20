using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

/*******************************************
* FICHIER CODE PAR BAPTISTE
********************************************/
public class dispawn : MonoBehaviour
{
    public AudioSource laPiste;
    public AudioClip sonMort;

    void Start()
    {
        laPiste = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.tag == "ennemi")
        {
            laPiste.clip = sonMort;
            laPiste.Play();
        }
    }
}
