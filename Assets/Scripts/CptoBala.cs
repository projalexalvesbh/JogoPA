using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CptoBala : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

        Debug.logger.Log("iniciou !!");

        GameObject player = GameObject.Find("player");

        float direcao = player.GetComponent<SpriteRenderer>().flipX ? -1 : 1;

        gameObject.GetComponent<SpriteRenderer>().flipX = player.GetComponent<SpriteRenderer>().flipX;

        Rigidbody2D rigidbody3 = gameObject.GetComponent<Rigidbody2D>();

        rigidbody3.AddForce(gameObject.transform.right * 50, ForceMode2D.Impulse);
    }

    void Update()
    {

        Destroy(gameObject, 2.5f);
    }

    private void OnCollisionEnter2D(Collision2D inimigoCollider)
    {
        Debug.logger.Log("Colidiu !!");

        Destroy(inimigoCollider.gameObject);

        Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D inimigoCollider)
    {
        Debug.logger.Log("Colidiu !!");

        Destroy(inimigoCollider.gameObject);

        Destroy(gameObject);
    }
}
