
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerFill : MonoBehaviour
{
    public GameObject pivo1;
    public GameObject pivo;
    Vector3 ScaleChange = new Vector3(0.01f, 0.0f, 0.0f);
    bool direction = false;
    Vector3 NullSetter = new Vector3(0.001f, 1, 1);
    Vector3 ObjectScale;
    
    
    // Start is called before the first frame update
    void Start()
    {
   
        transform.localScale = new Vector3 (0.0f, 2.8f, 2.8f);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space) && !direction)
                {
            Debug.Log("space down");
            transform.localScale += ScaleChange;
           if(transform.localScale.x > 4.4f)
            {
                Debug.Log("Reverse situation");
                    direction = true;
            }
               }

        if (Input.GetKey(KeyCode.Space) && direction)
        {
            transform.localScale -= ScaleChange;
            if (transform.localScale.x <= 0.0f)
            {
                Debug.Log("Reverse situation");
                    direction = false;
            }
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            StartCoroutine(Coroutine());
        }

    }
    private IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(3);
        ObjectScale = transform.localScale;
        ObjectScale.x *= -1;
        ObjectScale.y = 2.8f;
        ObjectScale.z = 2.8f;
        transform.localScale = ObjectScale;
      
      
        pivo1.SetActive(true);
       
       
        pivo.SetActive(false);
    }

}

