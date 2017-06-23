using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject objeto;
    
    float timeLeft = 3f;


    // Use this for initialization
    void Start()
    {

        criarObjeto();
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            criarObjeto();

            timeLeft = 5f;
        }
    }

    GameObject criarObjeto()

    {
        float direcao = Random.Range(-1f, 1f);

        Vector3 vec = new Vector3( (direcao>=0 ? 4.7f : -4.7f), Random.Range(- 1.63f , -2.58f), 0f);

        GameObject obj = Instantiate(objeto, vec, new Quaternion()) as GameObject;

        return obj;
    }


    
}


