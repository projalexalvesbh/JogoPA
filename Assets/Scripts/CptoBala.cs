using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CptoBala : MonoBehaviour
{

    public Rigidbody2D rigidbody2;

    // Use this for initialization
    void Start()
    {

        Debug.logger.Log("iniciou !!");

        GameObject player = GameObject.Find("player");

        float direcao = player.GetComponent<SpriteRenderer>().flipX ? -1 : 1;

        rigidbody2.AddForce(new Vector3(direcao, 0) * 500);
    }

    void Update()
    {

        Destroy(gameObject, 2.5f);
    }

    private void OnTriggerEnter2D(Collider2D inimigoCollider)
    {
        Debug.logger.Log("Colidiu !!");

        Destroy(inimigoCollider.gameObject);

        Destroy(gameObject);
    }
}
