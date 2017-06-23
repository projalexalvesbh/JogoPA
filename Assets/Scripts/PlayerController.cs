using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Transform playerTransform;

    public Transform bala;

    public GameObject barraVida;

    public Animator animator;

    public Rigidbody2D playerRigidbody;

    public SpriteRenderer playerSpriteRenderer;

    public BoxCollider2D playerBoxCollider;

    public bool atirando;
    public bool andando;

    float vidaAtual;

    float vida = 100;

    // Use this for initialization
    void Start () {

        vidaAtual = vida;

    }

    void setDano(int dano)
    {
        vidaAtual -= dano;
        //Destroy(inimigoCollider.gameObject.GetComponent<Rigidbody2D>());

        Debug.logger.Log("VIDA - " + vidaAtual);

        barraVida.SendMessage("setVida", vidaAtual / vida);

        if (vidaAtual <= 0)
        {

            animator.SetBool("morrendo", true);

            Destroy(gameObject, gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + 1f);
        }
        //gameObject.GetComponent<Animator>().SetBool("roboFire", false);

        //gameObject.GetComponent<Animator>().SetBool("roboAndando", false);

        //gameObject.GetComponent<Animator>().SetBool("roboDie", true);

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown("tiro"))
        {

            atirando = true;

            Transform tiro = Instantiate(bala, new Vector2(playerTransform.position.x + (0.35f * (playerTransform.GetComponent<SpriteRenderer>().flipX ? -1f : 1f)), playerTransform.position.y + 0.1f), Quaternion.identity);

            tiro.SendMessage("setPlayer", gameObject);
        }

        if (Input.GetButtonUp("tiro"))
        {
            
            atirando = false;
        }

        if (Input.GetButton("Horizontal"))
        {
            float velocidade = 0.05f;

            andando = true;
            if (Input.GetAxisRaw("Horizontal") > 0 && playerTransform.position.x < 4.7)
            {
                playerSpriteRenderer.flipX = false;

                playerTransform.position = new Vector3(playerTransform.position.x + velocidade, playerTransform.position.y);
            }
            if (Input.GetAxisRaw("Horizontal") < 0 && playerTransform.position.x >= -4.70)
            {
                playerSpriteRenderer.flipX = true;

                playerTransform.position = new Vector3(playerTransform.position.x - velocidade, playerTransform.position.y);
            }
        }

        if (Input.GetButtonUp("Horizontal"))
        {
            andando = false;
                
        }

        if (Input.GetButton("Vertical")){

            andando = true;

            if (Input.GetAxisRaw("Vertical") > 0 && playerTransform.position.y < -1.58f)
            {

                playerTransform.position = new Vector2(playerTransform.position.x, playerTransform.position.y + 0.02f);
            }

            if (Input.GetAxisRaw("Vertical") < 0 && playerTransform.position.y > -2.58f)
            {
                playerTransform.position = new Vector2(playerTransform.position.x, playerTransform.position.y - 0.02f);
            }
        }

        if (Input.GetButtonUp("Vertical"))
        {
            andando = false;

        }

        animator.SetBool("atirando", atirando);
        animator.SetBool("andando", andando);
    }

    private void OnCollisionEnter2D(Collision2D inimigoCollider)
    {
        Debug.logger.Log("Colisao" + inimigoCollider.gameObject.tag);

        if (!inimigoCollider.gameObject.name.StartsWith("balaRobo"))
        {

            Physics2D.IgnoreCollision(inimigoCollider.collider, inimigoCollider.otherCollider, true);
            Physics2D.IgnoreCollision(inimigoCollider.otherCollider, inimigoCollider.collider, true);
        }
    }
}
