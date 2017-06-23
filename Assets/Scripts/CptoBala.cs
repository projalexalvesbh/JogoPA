using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CptoBala : MonoBehaviour
{
    public GameObject player;

    // Use this for initialization
    void Start()
    {

        if (player == null)
        {
            Debug.logger.Log("Null");

            player = GameObject.Find("player");
        }

        iniciarBala();

    }
    void Update()
    {


    }

    void setPlayer(GameObject player)
    {
        this.player = player;
    }

    void iniciarBala()
    {
        float direcao = player.GetComponent<SpriteRenderer>().flipX ? -1 : 1;

        gameObject.GetComponent<SpriteRenderer>().flipX = player.GetComponent<SpriteRenderer>().flipX;

        Rigidbody2D rigidbody3 = gameObject.GetComponent<Rigidbody2D>();

        rigidbody3.AddForce(new Vector3(1, 0) * 250 * direcao, ForceMode2D.Force);

        Destroy(gameObject, 5.5f);
    }

    private void OnCollisionEnter2D(Collision2D inimigoCollider)
    {

        if (inimigoCollider.gameObject.name.Equals("Robo(Clone)") && inimigoCollider.otherCollider.gameObject.name.Equals("bala(Clone)"))
        {
            Debug.logger.Log("Player: " + inimigoCollider.gameObject.name);

            Destroy(inimigoCollider.gameObject.GetComponent<Rigidbody2D>());

            inimigoCollider.gameObject.GetComponent<Animator>().SetBool("roboFire", false);

            inimigoCollider.gameObject.GetComponent<Animator>().SetBool("roboAndando", false);

            inimigoCollider.gameObject.GetComponent<Animator>().SetBool("roboDie", true);

            Destroy(inimigoCollider.gameObject, inimigoCollider.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + 1f);

            Destroy(gameObject);
        }
        else
        {
            Physics2D.IgnoreCollision(inimigoCollider.otherCollider, inimigoCollider.collider, true);
            Physics2D.IgnoreCollision(inimigoCollider.collider, inimigoCollider.otherCollider, true);
        }


        if (inimigoCollider.gameObject.name.Equals("player") && inimigoCollider.otherCollider.gameObject.name.StartsWith("balaRobo"))
        {

            Debug.logger.Log("DANO - 10");

            inimigoCollider.gameObject.SendMessage("setDano", 10);

            Destroy(gameObject);
        }
        else
        {
            Physics2D.IgnoreCollision(inimigoCollider.otherCollider, inimigoCollider.collider, true);
            Physics2D.IgnoreCollision(inimigoCollider.collider, inimigoCollider.otherCollider, true);
        }


        if (inimigoCollider.gameObject.name.StartsWith("bala") && inimigoCollider.otherCollider.gameObject.name.StartsWith("bala"))
        {

            Physics2D.IgnoreCollision(inimigoCollider.otherCollider, inimigoCollider.collider, true);
            Physics2D.IgnoreCollision(inimigoCollider.collider, inimigoCollider.otherCollider, true);

            Destroy(inimigoCollider.gameObject);
            Destroy(inimigoCollider.otherCollider.gameObject);
        }
    }
}

