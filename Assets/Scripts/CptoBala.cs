﻿using System.Collections;
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

        rigidbody3.AddForce(gameObject.transform.right * 150 * direcao, ForceMode2D.Force);
    }

    void Update()
    {

        Destroy(gameObject, 5.5f);
    }

    private void OnCollisionEnter2D(Collision2D inimigoCollider)
    {
        Debug.logger.Log("Colidiu !!" + inimigoCollider.gameObject.tag);

        if(inimigoCollider.gameObject.tag.Equals("Robo")){

            inimigoCollider.gameObject.GetComponent<Animator>().SetBool("roboFire", false);

            inimigoCollider.gameObject.GetComponent<Animator>().SetBool("roboAndando", false);

            inimigoCollider.gameObject.GetComponent<Animator>().SetBool("roboDie", true);

            new WaitForSeconds(10f);

            Destroy(inimigoCollider.gameObject, inimigoCollider.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + 1f);

            Destroy(gameObject);
        }
    }

}
