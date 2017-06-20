using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {

    public GameObject objeto;
    public List<GameObject> objetos = new List<GameObject>();
    float timeLeft = 3f;

    // Use this for initialization
    void Start() {

        GameObject go = criarObjeto();

        objetos.Add(go);
    }

    // Update is called once per frame
    void Update() {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            objetos.Add(criarObjeto());

            timeLeft = 9f;
        }

        foreach (GameObject element in objetos)
        {

            andar(element);
        }
    }

    GameObject criarObjeto()
    {
        Vector3 vec = new Vector3(4.7f, -1.63f);

        GameObject obj = Instantiate(objeto, vec, new Quaternion()) as GameObject;
        SpriteRenderer sr = (SpriteRenderer)obj.GetComponent<SpriteRenderer>();

        Animator animator = obj.GetComponent<Animator>();

        Transform PlayerTransform = obj.GetComponent<Transform>();

        BoxCollider2D playerBoxCollider = (BoxCollider2D)obj.GetComponent<BoxCollider2D>();

        animator.SetBool("andando", true);

        andar(sr, PlayerTransform, playerBoxCollider);

        //animator.SetBool("atirando", atirando);


        float variacao = Random.Range(0.06f, 0.8f);

        playerBoxCollider.offset = new Vector2(playerBoxCollider.offset.x, -.5f - (variacao / 2));
        playerBoxCollider.size = new Vector2(playerBoxCollider.size.x, variacao);

        PlayerController pc = (PlayerController)obj.GetComponent<PlayerController>();

        Destroy(pc);

        sr.flipX = true;

        return obj;
    }


    void andar(GameObject obj)
    {

        SpriteRenderer sr = (SpriteRenderer)obj.GetComponent<SpriteRenderer>();

        Transform PlayerTransform = obj.GetComponent<Transform>();

        BoxCollider2D playerBoxCollider = (BoxCollider2D)obj.GetComponent<BoxCollider2D>();

        andar(sr, PlayerTransform, playerBoxCollider);

    }

    void andar(SpriteRenderer playerSpriteRenderer, Transform PlayerTransform, BoxCollider2D playerBoxCollider)
    {
        float velocidade = 0.03f;

        PlayerTransform.position = new Vector3(PlayerTransform.position.x - velocidade, PlayerTransform.position.y);


        if (playerSpriteRenderer.flipX && playerBoxCollider.size.y < 0.8f)
        {
            playerBoxCollider.offset = new Vector2(playerBoxCollider.offset.x, playerBoxCollider.offset.y - 0.01f);
            playerBoxCollider.size = new Vector2(playerBoxCollider.size.x, playerBoxCollider.size.y + 0.02f);
        }

        if (!playerSpriteRenderer.flipX && playerBoxCollider.size.y > 0.06f)
        {
            playerBoxCollider.offset = new Vector2(playerBoxCollider.offset.x, playerBoxCollider.offset.y + 0.01f);
            playerBoxCollider.size = new Vector2(playerBoxCollider.size.x, playerBoxCollider.size.y - 0.02f);
        }

    }
}


