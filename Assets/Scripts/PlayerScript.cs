using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    int nbPas;
    Rigidbody2D rbody;
    Animator anim;
    public Text nbPasText;
    Vector2 movement_vector;
    int walking;

    void OnGui()
    {
        GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "Test de message incroyablement fascinant");
    }

    // Use this for initialization
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        nbPas = 0;
        // nbPasText.text = "";
        walking = 0;
        movement_vector = new Vector2();
    }

    // Update is called once per frame
    void Update()
    {        
        // new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // Est-il à l'arrêt ?
        if(movement_vector == Vector2.zero)
        {
            // Si oui, on regarde s'il appuie
            if (Input.GetKey(KeyCode.RightArrow))
            {
                movement_vector.x = 1; // On va a droite   
                nbPas++;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                movement_vector.x = -1; // Gauche            
                nbPas++;
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                movement_vector.y = 1;
                nbPas++;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                movement_vector.y = -1;
                nbPas++;
            }
            else
            {
                anim.SetBool("walking", false);
            }
        }
        else
        {
            anim.SetBool("walking", true);
            if (walking < 60)
            {
                anim.SetFloat("input_x", (movement_vector.x));
                anim.SetFloat("input_y", (movement_vector.y));

                // nbPasText = nbPas.ToString();                        
                rbody.MovePosition(rbody.position + movement_vector / 64);
                walking++;
            }
            else
            {
                walking = 0;
                movement_vector = Vector2.zero;
            }
                
        }                                
    }
}
