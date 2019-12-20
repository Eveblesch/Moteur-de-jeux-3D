using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*******************************************
* FICHIER CODE PAR THOMAS
********************************************/
public class joueurNiveau3 : MonoBehaviour
{

    public commun affichages_communs;

    Rigidbody gravite;

    public AudioSource laPiste;
    public AudioClip sonSaut, sonMort;

    void Start()
    {
        gravite = GetComponent<Rigidbody>();
        laPiste = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(affichages_communs.pause==1 && (Input.GetButtonDown("Vertical") || Input.GetButtonDown("Jump")) && affichages_communs.vie > 0)
        {
            affichages_communs.pause = 0;
        }
        if (affichages_communs.debut == 0 && (Input.GetButtonDown("Vertical") || Input.GetButtonDown("Jump")))
        {
            affichages_communs.debut = 1;
            affichages_communs.instructionText.text = "";
        }
            
        //Déplacement
        if (affichages_communs.pause == 0 && affichages_communs.debut == 1)
        {
            transform.position += Vector3.forward * Time.deltaTime * affichages_communs.vitesse_avancement;
        }

        if (Input.GetButtonDown("Jump") && SurLeSol() && affichages_communs.vie > 0)
        {
            laPiste.clip = sonSaut;
            laPiste.Play();
            JumpRoutine();
        }
        
        if (!SurLeSol() && (transform.position.y > 1))
        {
            Physics.gravity = new Vector3(0, -40f, 0);
            GetComponent<Rigidbody>().useGravity = true;
            
        }

        if (SurLeSol())
        {
            Physics.gravity = new Vector3(0, -9.81f, 0);
        }
    }

    /*************************************************************
    * Fonction qui gère les collisions avec les obstacles
    * (perte de vie, reset du score, retour au départ)
    *************************************************************/
    void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.tag == "Obstacle")
        {
            affichages_communs.pause = 1;
            laPiste.clip = sonMort;
            laPiste.Play();
            transform.position = new Vector3(0f, 0.5f, -70f);
            affichages_communs.perteVie();
     
        }
        if (obj.gameObject.name == "MurInvisible")
        {
            StartCoroutine(affichages_communs.victoire());
        }
    }

    void JumpRoutine()
    {
        Vector3 jumpVector = new Vector3(0, 150, 0);

        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().AddForce(jumpVector, ForceMode.Impulse);
    }

    private bool SurLeSol()
    {
        Ray ray = new Ray(origin: transform.position, direction: Vector3.down);
        int layerMask = LayerMask.GetMask("Ground");
        if (Physics.Raycast(ray, maxDistance: 0.6f, layerMask: layerMask))
        {
            return true;
        }
        return false;
    }
}
