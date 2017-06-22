using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoController : MonoBehaviour {

    public Transform playerTransform;

    public Transform bala;

    public Animator animator;

    public SpriteRenderer playerSpriteRenderer;

    public BoxCollider2D playerBoxCollider;

    public bool atirando;
    public bool andando;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("tiro"))
        {

            atirando = true;

            Instantiate(bala, playerTransform.position, Quaternion.identity);
        }

        if (Input.GetButtonUp("tiro"))
        {
            Instantiate(bala, playerTransform.position, Quaternion.identity);

            atirando = false;
        }

        if (Input.GetButton("Horizontal"))
        {
            float velocidade = 0.04f;

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

            if (Input.GetAxisRaw("Vertical") > 0 && playerBoxCollider.size.y < 0.8f)
            {
                playerBoxCollider.offset = new Vector2(playerBoxCollider.offset.x, playerBoxCollider.offset.y - 0.01f);
                playerBoxCollider.size = new Vector2(playerBoxCollider.size.x, playerBoxCollider.size.y + 0.02f);
            }

            if (Input.GetAxisRaw("Vertical") < 0 && playerBoxCollider.size.y > 0.06f)
            {
                playerBoxCollider.offset = new Vector2(playerBoxCollider.offset.x, playerBoxCollider.offset.y + 0.01f);
                playerBoxCollider.size = new Vector2(playerBoxCollider.size.x, playerBoxCollider.size.y - 0.02f);
            }
        }

        if (Input.GetButtonUp("Vertical"))
        {
            andando = false;

        }


        animator.SetBool("atirando", atirando);
        animator.SetBool("andando", andando);
    }
}
