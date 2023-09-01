using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using System;
//IT SETS ASTEROID BACK BUT IT CONTINUES FALLING

public class Catapult : MonoBehaviour
{
    public GameObject turret1, turret1_ostecen, turret1_unisten, turret2, turret2_ostecen, turret2_unisten, nexus, nexus_ostecen, nexus_unisten;
    public Animator animator;
    public AudioClip blastSound;

    public GameObject HandlePivot;
    public GameObject fill;    // max value: 4.4f , 0f, 0f
    public GameObject asteroid;
    float scale, tilt, ydiff;
    float width, height;

    bool upward = true;
    float rot = 0f;
    Vector3 newPosition = new Vector3(0, 0, 0);

    Vector3 throwAngle;
    Vector3 initialAsteroid; 

    bool trigger;


    void Start()
    {
       trigger = false;
        initialAsteroid = asteroid.transform.position;
    }
    void Update()
    {
        if (HandlePivot.activeSelf)
        { 
                if (Input.GetKeyUp(KeyCode.Space))
                {
                      StartCoroutine(Coroutine());
                    //wait specifed amont for animation then enter loop
                    //....
                  


                }
        }
    
        //hand made collider  
        if(asteroid.transform.position.x > 3.85f && asteroid.transform.position.y > -1.65f && trigger)
        {
           width = asteroid.transform.position.x;
            height = asteroid.transform.position.y;
            if(width < 4.2f && height<-0.91f)
            {
                //collision turret #1
                trigger = false;
                asteroid.transform.position = initialAsteroid;
                AudioSource.PlayClipAtPoint(blastSound, Camera.main.transform.position);
                animator.SetTrigger("Explode");
                if (turret1_ostecen.activeSelf)
                {
                    turret1_ostecen.SetActive(false);
                    turret1_unisten.SetActive(true);
                }
                if (turret1.activeSelf)
                {
                    turret1.SetActive(false);
                    turret1_ostecen.SetActive(true);
                }

            }
            if(width > 5.43f && width < 5.75f && height < -0.57f)
            {
                //collision turret #2
                trigger = false;
                asteroid.transform.position = initialAsteroid;
                AudioSource.PlayClipAtPoint(blastSound, Camera.main.transform.position);
                animator.SetTrigger("Explode");
                if (turret2_ostecen.activeSelf)
                {
                    turret2_ostecen.SetActive(false);
                    turret2_unisten.SetActive(true);
                }
                if (turret2.activeSelf)
                {
                    turret2.SetActive(false);
                    turret2_ostecen.SetActive(true);
                }
            }
            if(width > 7.95f && width < 9f && height < 1.15f)
            {
                //collision nexus turret
                trigger = false;
                asteroid.transform.position = initialAsteroid;
                AudioSource.PlayClipAtPoint(blastSound, Camera.main.transform.position);
                animator.SetTrigger("Explode");
                if (nexus_ostecen.activeSelf)
                {
                    nexus_ostecen.SetActive(false);
                    nexus_unisten.SetActive(true);
                }
                if (nexus.activeSelf)
                {
                    nexus.SetActive(false);
                    nexus_ostecen.SetActive(true);
                }
            }


        }
        if (asteroid.transform.position.x > 9.3f)
        {
            trigger = false;
            asteroid.transform.position = initialAsteroid;
           // Debug.Log("HELLO NIGGA I AM INSIDE INITAL SETTER TRIGGER IS: "+trigger);
        }
        if (trigger && asteroid.transform.position.x < 9.4f)
        {
            //zasto trgier ponovo ne radi wtf
            /* Debug.Log("TRIGGER IS: " + trigger);
           //  Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");*/
           /* Debug.Log("I inside asteroid trajectory section, asteroid pozicija:" + asteroid.transform.position);
             Debug.Log("I inside asteroid trajectory section, cos(tilt), scale, ydiif pozicija:" + Mathf.Cos(tilt) + " " + scale + " " + ydiff);
           */
            ydiff -= 0.003f;
            asteroid.transform.position = asteroid.transform.position + new Vector3(scale * Mathf.Cos(tilt) / 17, ydiff / 17, 0);
        }
    }
   
    private IEnumerator Coroutine()
    {  //throwangle.z is consntant (nonsense)

        //first it increases rotation till its 20, then it reduces it to -40 (at a throw away point)
        throwAngle = HandlePivot.transform.eulerAngles;
        throwAngle.z = 21;
        //   Debug.Log("Angle" + throwAngle);

        //PODIZANJE
        while (rot > throwAngle.z - 80)
        {

            rot -= 1;
            newPosition = new Vector3(0, 0, rot);
            transform.eulerAngles = newPosition;
     
            yield return new WaitForSeconds(0.003f);
          

        }
        tilt = (float)Math.Round(Math.PI * (HandlePivot.transform.eulerAngles.z) / 180, 2);
       //old tilt tilt = (195 - throwAngle.z) / 90;
        scale = fill.transform.localScale.x / 4.4f;
        // old ydiff ydiff = (1 - (1 - ((1 - tilt) * scale)) / 3.5f);
        ydiff = Mathf.Sin(tilt) * scale;
        /* Debug.Log("throwangle.z, Tilt: " + HandlePivot.transform.eulerAngles.z + ", "+tilt);
           Debug.Log("scale: " + scale);
           Debug.Log("ydiff: " + ydiff);*/
        //SPUSTANJE
        while (rot < 17)
        {
            rot += 8;
            newPosition = new Vector3(0, 0, rot);
            transform.eulerAngles = newPosition;
            yield return new WaitForSeconds(0.03f);
        }
        //Bigger throwangle means lower catapult angle(in code it means bigger angle).

        trigger = true;





    }
        
}


