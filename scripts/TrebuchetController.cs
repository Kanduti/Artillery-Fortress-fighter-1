using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/*

 Najbolji trow treba da je na 150 stepeni.
w smanjuje a s povecava stepene/rotaciju.
Napraviti da powerFill utice na masu tega
 */
public class TrebuchetController : MonoBehaviour
{
    public Rigidbody2D weight;
    
    public GameObject player;
    private Vector3 currentPosition;
    public Rigidbody2D asteroid;
    bool halfcirlce = false;
    public Rigidbody2D Drska;
    public Rigidbody2D Rope;

    public GameObject throwAngle; //proxy variable
    public GameObject fill;   // maxvalue: 4.4f, 0, 0

    Vector3 angleVector;  // values:  105 dullest(vertical) 195 acutest(horizontal) angle

    Vector3 initalAsteroid;
    Vector3 initalWeight;
    Vector3 initalRope;
    Vector3 initalDrska;
    Vector3 ropeAngle;
    Vector3 drskaAngle;
    Vector3 weightAngle;

    float scale, ydiff;
    float tilt;

    void Start()
    {
        //ovo izgleda ne uklucuje rotaciju
        initalRope = Rope.transform.position;
        initalDrska = Drska.transform.position;
        initalAsteroid = asteroid.transform.position;
        initalWeight = weight.transform.position;
        ropeAngle = Rope.transform.rotation.eulerAngles;
        drskaAngle = Drska.transform.rotation.eulerAngles;
        weightAngle = weight.transform.rotation.eulerAngles;
       

    }

    
    void Update()
    {
        

        if (player.activeSelf)
        {

            
            if (Input.GetKeyUp(KeyCode.Space))
            { 

                asteroid.isKinematic = false;
                Rope.isKinematic = false;
                weight.isKinematic = false;

                Drska.isKinematic = false;

                halfcirlce = false;

              angleVector = throwAngle.transform.eulerAngles;

               // StartCoroutine(Delay());
                

            }
      
        }
        // throw animation
        if(!weight.isKinematic)
        {
            currentPosition = asteroid.transform.position;
          
            if(currentPosition.x > 8.5)
            {
                halfcirlce=true;
              //  Debug.Log("Angle of aim is: " + angleVector.z);
             //   Debug.Log("angle sum constituent" + (Math.Abs(angleVector.z - 105) * 0.0044f));
            }
            //8 is latest release. 8.4 earliest realse. 8.2 middle. 105 dullest(vertical) 195 acutest(horizontal) angle
            if(halfcirlce && currentPosition.x < 8.1)  //(Math.Abs(angleVector.z - 105) * 0.0044f)
            {
              
                Debug.Log("Joint release"); Debug.Log("Joint release");
                asteroid.GetComponent<FixedJoint2D>().enabled = false;

             halfcirlce = false;
                // Here we give bonus speed to our asteroid

                
                   tilt =(float)Math.Round(Math.PI * (195 - angleVector.z)/ 180,2);
            scale = fill.transform.localScale.x / 4.4f;

        ydiff = Mathf.Sin(tilt) * scale;
             /*   Debug.Log("throwangle.z, Tilt: " + HandlePivot.transform.eulerAngles.z + ", " + tilt);
                Debug.Log("scale: " + scale);
                Debug.Log("ydiff: " + ydiff);*/
                /*
                       ydiff -= 0.003f;
            asteroid.transform.position = asteroid.transform.position + new Vector3((scale * tilt) *2, ydiff * 2, 0);
                */
                //how to calculate x bonus? scale/tilt if tilt is 0 scale should be multiplied by one and by 0 if tilt is 1 so tilt should be in 1 - 0 spectrum
                asteroid.velocity += new Vector2((scale* Mathf.Cos(tilt)) > 0.5 ? (scale* Mathf.Cos(tilt))*4 :-(1-(Mathf.Cos(tilt)* scale))*4, ydiff >0.5 ? ydiff*2 :-(1-ydiff)*4);
            }
            Debug.Log("Pozicija asteroida: " + currentPosition);

            StartCoroutine(Coroutine());
        }
    }
    
   /* private  IEnumerator Delay()
    {

        yield return new WaitForSeconds(0.01f);

        weight.isKinematic = false;

        Drska.isKinematic = false;
     
        halfcirlce = false;

        angleVector = throwAngle.transform.eulerAngles;

        // i want to fit 90 into 0.4
        //0.004f is a step
}*/

    private IEnumerator Coroutine()
    {
        //waits 3 seconds and then just blasts this shit
    
        yield return new WaitForSeconds(3);

        asteroid.velocity = Vector3.zero;
        asteroid.angularVelocity = 0f;
        weight.velocity = Vector3.zero;
        weight.angularVelocity = 0f;
        Drska.velocity = Vector3.zero;
        Drska.angularVelocity = 0f;
        Rope.velocity = Vector3.zero;
        Rope.angularVelocity = 0f;


        Debug.Log("I am inside a coroutine");
     

        weight.isKinematic = true;
        asteroid.isKinematic = true;
        Drska.isKinematic = true;
        Rope.isKinematic = true;
       
        asteroid.transform.position = initalAsteroid;
        Rope.transform.position = initalRope;
        Drska.transform.position = initalDrska;
        weight.transform.position = initalWeight;
        Rope.transform.eulerAngles = ropeAngle;
        weight.transform.eulerAngles = weightAngle;
        Drska.transform.eulerAngles = drskaAngle;
       
        asteroid.GetComponent<FixedJoint2D>().enabled = true;

        

    }
}



