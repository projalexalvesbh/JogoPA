using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboScript : MonoBehaviour
{

    float timeLeft = 3f;

    // Use this for initialization
    void Start()
    {

        SpriteRenderer sr = (SpriteRenderer)gameObject.GetComponent<SpriteRenderer>();

        Transform PlayerTransform = gameObject.GetComponent<Transform>();

        Animator animator = gameObject.GetComponent<Animator>();

        //animator.SetBool("roboFire", true);

        andar();

        //animator.SetBool("atirando", true);

        sr.flipX = true;

    }

    // Update is called once per frame
    void Update()
    {

        andar();
    }


    void andar()
    {
        float velocidade = 0.04f;

        SpriteRenderer playerSpriteRenderer = (SpriteRenderer)GetComponent<SpriteRenderer>();

        int direcao = 1;

        if (gameObject.GetComponent<Animator>().GetBool("roboDie"))
        {
            //GetComponent<Animator>().SetBool("roboDie", true);
            return;
        }

        if (playerSpriteRenderer.flipX)
        {
            direcao = -1;

            if (transform.position.x >= 4.7)
            {
                playerSpriteRenderer.flipX = true;
            }
            if (transform.position.x <= -4.7)
            {
                playerSpriteRenderer.flipX = false;
            }
        }
        else
        {
            direcao = 1;
            if (transform.position.x <= -4.7)
            {
                playerSpriteRenderer.flipX = false;
            }
            if (transform.position.x >= 4.7)
            {
                playerSpriteRenderer.flipX = true;
            }
        }
        transform.position = new Vector3(transform.position.x + (velocidade * direcao), transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D inimigoCollider)
    {
        Debug.logger.Log("Colisao" + inimigoCollider.gameObject.tag);

        if (inimigoCollider.gameObject.tag == "Robo")
        {

            Debug.logger.Log("Colisao robos");
            Physics2D.IgnoreCollision(inimigoCollider.collider, inimigoCollider.otherCollider, true);
        }
    }
}