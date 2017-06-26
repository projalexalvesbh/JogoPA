using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{

    public GameObject player;

    public GameObject objeto;
<<<<<<< HEAD
    
    float timeLeftInicial = 3f;
=======

    public GameObject fundo;

    float timeLeft = 3f;
>>>>>>> 8a65d45bb04a88b862a84685756f133b62282f8d

    int contadorFase1 = 0;

    List<GameObject> inimigos = new List<GameObject>();


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

<<<<<<< HEAD
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
=======
        if (contadorFase1 <= 10)
        {

            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                criarObjeto();

                timeLeft = 5f;
            }
        }
        else
        {
            GameObject gameAux = null;

            foreach (GameObject obj in inimigos){
                if(obj != null)
                {
                    gameAux = obj;
                    break;
                }
            }

            if (gameAux = null)
            {
                fundo.transform.position = new Vector3(fundo.transform.position.x, fundo.transform.position.y, fundo.transform.position.z + 0.02f);
            }
>>>>>>> 8a65d45bb04a88b862a84685756f133b62282f8d
        }
    }

    GameObject criarObjeto()

    {
        float direcao = Random.Range(-1f, 1f);

        Vector3 vec = new Vector3( (direcao>=0 ? 4.7f : -4.7f), Random.Range(- 1.63f , -2.58f), 0f);

        GameObject obj = Instantiate(objeto, vec, new Quaternion()) as GameObject;

        inimigos.Add(obj);

        contadorFase1++;

        return obj;
    }


    
}


