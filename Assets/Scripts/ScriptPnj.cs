using UnityEngine;
using System.Collections;

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
                
        Random rnd = new Random();
        int random_x = rnd.Next(1);
        int random_y = rnd.Next(1);
        Vector2 movement_vector = new Vector2(random_x,random_y);

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
