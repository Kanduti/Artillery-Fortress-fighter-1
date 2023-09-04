using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject bnex, bt1, bt2, gnex, gt1, gt2, bd1, bd2, bdn, gd1,gd2,gdn;
    public GameObject bres, bres1, bres2, gres, gres1, gres2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bnex.activeSelf &&  bt1.activeSelf && bt2.activeSelf)
        {
            StartCoroutine(Coroutine1());
        }
        if(gnex.activeSelf && gt1.activeSelf && gt2.activeSelf)
        {
            StartCoroutine(Coroutine2());
        }
    }
    private IEnumerator Coroutine1()
    {
        yield return new WaitForSeconds(1);
        bres.SetActive(true);
        bres1.SetActive(true);
        bres2.SetActive(true);
        bnex.SetActive(false);
        bt1.SetActive(false);
        bt2.SetActive(false);

        gres.SetActive(true);
        gres1.SetActive(true);
        gres2.SetActive(true);
        gnex.SetActive(false);
        gt1.SetActive(false);
        gt2.SetActive(false);
        gdn.SetActive(false);
        gd1.SetActive(false);
        gd2.SetActive(false);


    }
    private IEnumerator Coroutine2()
    {
        yield return new WaitForSeconds(1);
        gres.SetActive(true);
        gres1.SetActive(true);
        gres2.SetActive(true);
        gnex.SetActive(false);
        gt1.SetActive(false);
        gt2.SetActive(false);

        bres.SetActive(true);
        bres1.SetActive(true);
        bres2.SetActive(true);
        bnex.SetActive(false);
        bt1.SetActive(false);
        bt2.SetActive(false);
        bdn.SetActive(false);
        bd1.SetActive(false);
        bd2.SetActive(false);
    }
}
