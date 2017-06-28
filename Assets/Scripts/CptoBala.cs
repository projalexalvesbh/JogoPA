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

        GameObject[] objs = GameObject.FindGameObjectsWithTag("bala");

        foreach (GameObject objects in objs)
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), objects.GetComponent<Collider2D>(), true);
            Physics2D.IgnoreCollision(objects.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
        }
        Destroy(gameObject, 5.5f);
    }

    private void OnCollisionEnter2D(Collision2D inimigoCollider)
    {

        Debug.logger.Log("Atirador: " + player.tag);

        Debug.logger.Log("NAME INIMIGO: " + inimigoCollider.gameObject.name + " : NAME GAMEOBJECT: " + gameObject.name);

        if ((inimigoCollider.gameObject.name.StartsWith("Robo") && !player.tag.Equals("Player")) ||
            (inimigoCollider.gameObject.name.StartsWith("Player") && !player.name.StartsWith("Robo")))
        {

            Debug.logger.Log("Ignorar: Inimigo errado!");
            Physics2D.IgnoreCollision(inimigoCollider.collider, GetComponent<Collider2D>(), true);
            Physics2D.IgnoreCollision(inimigoCollider.otherCollider, GetComponent<Collider2D>(), true);
        }
        else if (inimigoCollider.gameObject.name.StartsWith("bala"))
        {

            Debug.logger.Log("Ignorar: Entre Balas");

            Physics2D.IgnoreCollision(inimigoCollider.collider, GetComponent<Collider2D>(), true);
            Physics2D.IgnoreCollision(inimigoCollider.otherCollider, GetComponent<Collider2D>(), true);

            //Destroy(inimigoCollider.gameObject);
            //Destroy(inimigoCollider.otherCollider.gameObject);
        }
        else if (inimigoCollider.gameObject.name.StartsWith("Robo") && gameObject.name.StartsWith("balaPlayer"))
        {
            Debug.logger.Log("Dano: Robo");

            Destroy(inimigoCollider.gameObject.GetComponent<Rigidbody2D>());

            inimigoCollider.gameObject.GetComponent<Animator>().SetBool("roboFire", false);

            inimigoCollider.gameObject.GetComponent<Animator>().SetBool("roboAndando", false);

            inimigoCollider.gameObject.GetComponent<Animator>().SetBool("roboDie", true);

            player.gameObject.SendMessage("setPontos", 100);

            Destroy(inimigoCollider.gameObject, inimigoCollider.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + 1f);

            Destroy(gameObject);
        }
        else if (inimigoCollider.gameObject.name.Equals("player") && gameObject.name.StartsWith("balaRobo"))
        {
            Debug.logger.Log("Dano: Player");

            inimigoCollider.gameObject.SendMessage("setDano", 10);

            Destroy(gameObject);

            Physics2D.IgnoreCollision(inimigoCollider.collider, GetComponent<Collider2D>(), true);
        }
        else
        {

            Debug.logger.Log("Ignorar Tudo");
            //Physics2D.IgnoreCollision(inimigoCollider.otherCollider, inimigoCollider.collider, true);
            Physics2D.IgnoreCollision(inimigoCollider.collider, GetComponent<Collider2D>(), true);
        }
    }
}

