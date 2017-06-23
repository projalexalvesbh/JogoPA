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

            timeLeft = 9f;
        }
    }

    GameObject criarObjeto()
    {
        Vector3 vec = new Vector3(4.7f, -1.63f, 0f);

        GameObject obj = Instantiate(objeto, vec, new Quaternion()) as GameObject;

        return obj;
    }


    
}


