using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboScript : MonoBehaviour
{

    public Transform bala;

    float timeLeft = 2f;

    // Use this for initialization
    void Start()
    {

        SpriteRenderer sr = (SpriteRenderer)gameObject.GetComponent<SpriteRenderer>();

        andar();

        sr.flipX = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (!gameObject.GetComponent<Animator>().GetBool("roboDie"))
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {

                atirar();

                timeLeft = 2f;
            }
            else
            {
                gameObject.GetComponent<Animator>().SetBool("roboAndando", true);

                andar();
            }
        }
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

    void atirar()
    {
        gameObject.GetComponent<Animator>().SetBool("roboFire", true);

        Transform tiro = Instantiate(bala, new Vector2(transform.position.x + (0.35f * (transform.GetComponent<SpriteRenderer>().flipX ? -1f : 1f)), transform.position.y + 0.1f), Quaternion.identity);

        Physics2D.IgnoreCollision(tiro.GetComponent<Collider2D>() ,GetComponent<Collider2D>(), true);

        GameObject[] objs = GameObject.FindGameObjectsWithTag("Robo");

        foreach (GameObject objects in objs)
        {

            Physics2D.IgnoreCollision(tiro.GetComponent<Collider2D>(), objects.GetComponent<Collider2D>(), true);
        }


        tiro.SendMessage("setPlayer", gameObject);
    }

    private void OnCollisionEnter2D(Collision2D inimigoCollider)
    {
        if (!inimigoCollider.gameObject.tag.StartsWith("balaPlayer"))
        {

            Physics2D.IgnoreCollision(inimigoCollider.collider, inimigoCollider.otherCollider, true);
            Physics2D.IgnoreCollision(inimigoCollider.otherCollider, inimigoCollider.collider, true);
        }
    }
}