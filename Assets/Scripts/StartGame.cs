using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{

    public GameObject player;

    public GameObject objeto;
    
    float timeLeftInicial = 3f;


    float timeLeft;
    // Use this for initialization
    void Start()
    {

        timeLeft = timeLeftInicial;

        criarObjeto();
    }

    // Update is called once per frame
    void Update()
    {

        if(player == null)
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            timeLeftInicial -= timeLeftInicial> 0.3f ? 0.02f : 0f;

            criarObjeto();

            timeLeft = timeLeftInicial;
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


