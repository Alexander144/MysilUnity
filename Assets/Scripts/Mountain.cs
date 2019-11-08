using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mountain : MonoBehaviour
{
    public Animator LeftEye;
    public Animator RightEye;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayEyeAnimation());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator PlayEyeAnimation()
    {
        yield return new WaitForSeconds(5);
        LeftEye.SetBool("Run", true);
        RightEye.SetBool("Run", true);
        StartCoroutine(PlayEyeAnimation());
    }
}
