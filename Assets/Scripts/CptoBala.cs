using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CptoBala : MonoBehaviour {

    public Rigidbody2D rigidbody;

    // Use this for initialization
    void Start () {
        GameObject player = GameObject.Find("player");

        rigidbody = gameObject.GetComponent<Rigidbody2D>();

        float direcao = player.GetComponent<SpriteRenderer>().flipX ? -1 : 1;

        rigidbody.AddForce(new Vector3(direcao,0) * 500);
	}
	
	// Update is called once per frame
	void Update () {

        Destroy(gameObject, 1.5f);
	}

    private void OnTriggerEnter(Collider inimigoCollider)
    {
        //if (inimigoCollider.GetComponent<Collider>().tag == "Inimigo")
        //{
            Destroy(inimigoCollider.gameObject);

            Destroy(gameObject);
        //}
    }
}
