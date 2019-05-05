using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutRadar : MonoBehaviour
{
    private GameObject donut;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (donut == null)
            donut = GameObject.FindWithTag("Donuts");

        if (donut != null)
        {
            LookAt(donut.transform.position);
            anim.SetBool("Enabled", !donut.GetComponent<Donuts>().donutIsVisible);
        }
    }

    void LookAt(Vector3 targetPosition)
    {
        //usar transfor.up se a face da sprite estiver pra cima
        //atentar para que o position.z do target seja SEMPRE instanciado em zero
        transform.up = targetPosition - transform.position;     
    }
}
