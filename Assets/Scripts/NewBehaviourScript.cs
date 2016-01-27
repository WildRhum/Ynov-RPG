using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour
{
    int nbPas = 0;
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
        Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
/*
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed / 5); // On va a droite
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * speed / 5); // Gauche
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * speed / 5);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.down * speed / 5);
        }*/

        // switch chase a faire

        if (movement_vector != Vector2.zero)
        {
            anim.SetBool("walking", true);
            anim.SetFloat("input_x", movement_vector.x);
            anim.SetFloat("input_y", movement_vector.y);
            nbPas++;
        }
        else
        {
            anim.SetBool("walking", false);
        }

        rbody.MovePosition(rbody.position + movement_vector * Time.deltaTime);
    }
}
