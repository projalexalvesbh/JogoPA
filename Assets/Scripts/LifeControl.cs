using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeControl : MonoBehaviour {

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setVida(float indiceVida)
    {
        transform.localScale = new Vector3(indiceVida, 1, 1);
    }
}
