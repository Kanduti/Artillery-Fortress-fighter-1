using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;


public class Strela : MonoBehaviour
{
   
    int brzinaRotacije = 7;
    int rot = 0;
    const float poluprecnikStrelice = 0.95f;
    const float kvadratStrelice = 0.90f;
    Vector3 newPosition;
   // public gameObject pivot;
    public GameObject pivot2;
    int x = 1;
    int initialIncline = 0;
    // Start is called before the first frame update
    
    void Start()
    {
       if(pivot2.activeSelf)
        {
            x *= -1;
            initialIncline = 170;
        }

        newPosition = new Vector3(0, 0, initialIncline);
        transform.eulerAngles = newPosition;

        Debug.Log("Initial incline" + initialIncline);
    }

    // Update is called once per frame
    void Update()
    {
        
   
        if (Input.GetKey(KeyCode.W))
        {
            rot += x;
            newPosition = new Vector3(0, 0, rot+initialIncline);
        transform.eulerAngles = newPosition;
            Debug.Log(rot+initialIncline +" :rotacija");
            
          
       }
        
        else if (Input.GetKey(KeyCode.S))
        {
            rot -= x;
            newPosition = new Vector3(0, 0, rot+initialIncline);
            transform.eulerAngles = newPosition;
            Debug.Log(rot+initialIncline + " :rotacija");
            
        }
        
    }
    
    
}
