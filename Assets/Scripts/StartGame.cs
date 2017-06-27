﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StartGame : MonoBehaviour
{

    public GameObject player;

    public GameObject objeto;

    float timeLeftInicial = 3f;

    public GameObject fundoBeco;

    public GameObject fundoBrasil;

    public Text fimJogo;

    public Button btnReiniciar;

    int contadorFase1 = 0;

    int fase = 1;

    List<GameObject> inimigos = new List<GameObject>();

    float timeLeft;

    // Use this for initialization
    void Start()
    {

        btnReiniciar.gameObject.SetActive(false);

        timeLeft = timeLeftInicial;

        criarObjeto();
    }

    // Update is called once per frame
    void Update()
    {

        if (player == null)
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            timeLeftInicial -= timeLeftInicial > 0.3f ? 0.02f : 0f;

            if (contadorFase1 < 5)
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

                Debug.logger.Log("Contador: " + contadorFase1);

                GameObject gameAux = null;

                foreach (GameObject obj in inimigos)
                {
                    if (obj != null)
                    {
                        gameAux = obj;
                        break;
                    }
                }

                if (gameAux == null)
                {
                    if (fase == 1)
                    {
                        fundoBeco.transform.position = new Vector3(fundoBeco.transform.position.x, fundoBeco.transform.position.y, fundoBeco.transform.position.z + 0.2f);
                    }
                    else if (fase == 2)
                    {
                        fundoBrasil.transform.position = new Vector3(fundoBrasil.transform.position.x, fundoBrasil.transform.position.y, fundoBrasil.transform.position.z + 0.2f);
                    }
                    else
                    {
                        //Application.LoadLevel(Application.loadedLevel);
                        fimJogo.text = "Fim de Jogo !";

                        Time.timeScale = 0;

                        btnReiniciar.gameObject.SetActive(true);

                        btnReiniciar.onClick.AddListener(delegate { reiniciar(); });

                        Application.Quit();
                    }

                    fase++;

                    contadorFase1 = 0;
                }
                else
                {

                    Debug.logger.Log("Encontrou !" + gameAux.name);
                }
            }
        }
    }

    public void reiniciar()
    {
        Time.timeScale = 1;

        Application.LoadLevel(Application.loadedLevel);
    }
    GameObject criarObjeto()

    {
        float direcao = Random.Range(-1f, 1f);

        Vector3 vec = new Vector3((direcao >= 0 ? 4.7f : -4.7f), Random.Range(-1.63f, -2.58f), 0f);

        GameObject obj = Instantiate(objeto, vec, new Quaternion()) as GameObject;

        inimigos.Add(obj);

        contadorFase1++;

        return obj;
    }
}


