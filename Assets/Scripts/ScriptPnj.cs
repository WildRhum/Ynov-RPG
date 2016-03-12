using UnityEngine;
using System.Collections;
using System.Threading;
using System;

public class ScriptPnj : MonoBehaviour {    
    Rigidbody2D rbody;
    Animator anim;

    // Initialisation des variables
    float random_x = 0;
    float random_y = 0;
    Vector2 movement_vector = new Vector2(-3,-3);
    int boucle_wait = 0;

    // Use this for initialization
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();        
    }

    // Update is called once per frame
    void Update()
    {        
        // -3 est utilisé arbitrairement comme valeur de non mouvement
        if(movement_vector == new Vector2(-3,-3))
        {
            boucle_wait++;
            if(boucle_wait > 120)
            {
                anim.SetBool("walking", false);
                boucle_wait = 0;
                movement_vector = new Vector2(0,0);
            }            
        }
        // Si le personne doit faire un mouvement et n'a pas terminé, il continu son mouvement
        else if (rbody.position != (rbody.position + movement_vector))
        {
            boucle_wait++;
            if (boucle_wait > 120)
            {
                anim.SetBool("walking", false);
                boucle_wait = 0;
                movement_vector = new Vector2(-3, -3);
            }
            else
            {
                rbody.MovePosition(rbody.position + movement_vector);
            }
        }
        // Sinon, un aléatoire détermine s'il bougera ou non et où
        else
        {
            System.Random random = new System.Random();
            random_x = 0;
            random_y = 0;

            // génération d'un aléatoire
            int randomInt = random.Next(100);

            // 1/3 d'attente
            if(randomInt % 3 == 0)
            {
                movement_vector = new Vector2(-3,-3);
                return;
            }
            // Si < a 50, il bougera horizontalement
            else if (randomInt < 50)
            {
                random_x = ((float)random.NextDouble() * Math.Abs(1 - (-1)) + (-1))/25;
            }
            // Si > a 50, il bougera verticallement
            else
            {
                random_y = ((float)random.NextDouble() * Math.Abs(1 - (-1)) + (-1))/25;
            }

            // Création du vecteur de déplacement
            movement_vector = new Vector2(random_x, random_y);
            
            if (movement_vector != Vector2.zero)
            {
                anim.SetBool("walking", true);
                anim.SetFloat("input_x", movement_vector.x);
                anim.SetFloat("input_y", movement_vector.y);
            }
        }                
    }
}
