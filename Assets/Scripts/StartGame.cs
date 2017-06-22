using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{


    public GameObject objeto;
    public List<GameObject> objetos = new List<GameObject>();
    float timeLeft = 3f;


    // Use this for initialization
    void Start()
    {

        GameObject go = criarObjeto();

        objetos.Add(go);
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            objetos.Add(criarObjeto());

            timeLeft = 9f;
        }

        foreach (GameObject element in objetos)
        {
            if (element != null)
            {
                andar(element);
            }
        }
    }

    GameObject criarObjeto()
    {
        Vector3 vec = new Vector3(4.7f, -1.63f, 0f);

        GameObject obj = Instantiate(objeto, vec, new Quaternion()) as GameObject;

        SpriteRenderer sr = (SpriteRenderer)obj.GetComponent<SpriteRenderer>();

        Transform PlayerTransform = obj.GetComponent<Transform>();

        Animator animator = obj.GetComponent<Animator>();

        animator.SetBool("andando", true);

        andar(sr, PlayerTransform);

        //animator.SetBool("atirando", true);

        sr.flipX = true;

        return obj;
    }


    void andar(GameObject obj)
    {

        SpriteRenderer sr = (SpriteRenderer)obj.GetComponent<SpriteRenderer>();

        Transform PlayerTransform = obj.GetComponent<Transform>();

        andar(sr, PlayerTransform);

    }

    void andar(SpriteRenderer playerSpriteRenderer, Transform playerTransform)
    {
        float velocidade = 0.03f;

        int direcao = 1;

        if (playerSpriteRenderer.flipX)
        {
            direcao = -1;

            if (playerTransform.position.x >= 4.7)
            {
                playerSpriteRenderer.flipX = true;
            }
            if (playerTransform.position.x <= -4.7)
            {
                playerSpriteRenderer.flipX = false;
            }
        }
        else
        {
            direcao = 1;
            if (playerTransform.position.x <= -4.7)
            {
                playerSpriteRenderer.flipX = false;
            }
            if (playerTransform.position.x >= 4.7)
            {
                playerSpriteRenderer.flipX = true;
            }
        }
        playerTransform.position = new Vector3(playerTransform.position.x + (velocidade * direcao), playerTransform.position.y);
    }
}


