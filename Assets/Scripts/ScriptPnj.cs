using UnityEngine;
using System.Collections;
using System.Threading;
using System;

public class ScriptPnj : MonoBehaviour {    
    Rigidbody2D rbody;
    Animator anim;
    // Use this for initialization
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {        
        int vectorX, vectorY;

        System.Random random = new System.Random();

        float random_x = 0;
        float random_y = 0;
        
        if(random.Next(100) < 50)
        {
            random_x = (float)random.NextDouble() * Math.Abs(1 - (-1)) + (-1);
        }
        else
        {
            random_y = (float)random.NextDouble() * Math.Abs(1 - (-1)) + (-1);
        }
        
        Vector2 movement_vector = new Vector2(random_x, random_y);

        if (movement_vector != Vector2.zero)
        {
            anim.SetBool("walking", true);
            anim.SetFloat("input_x", movement_vector.x);
            anim.SetFloat("input_y", movement_vector.y);            
        }
        else
        {
            anim.SetBool("walking", false);
        }

        rbody.MovePosition(rbody.position + movement_vector * Time.deltaTime);
    }
}
