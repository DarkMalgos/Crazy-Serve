﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenDrink : MonoBehaviour
{
[SerializeField]
    private GameObject PrefabBoissonVerte;

    private GameObject plate;

    private bool isPickUp = true;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && !isPickUp && tag == "Machine Verte"){
                    isPickUp = true;
                    GameObject BoissonVerte = Instantiate(PrefabBoissonVerte);
                    BoissonVerte.transform.SetParent(plate.transform);
        }
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.transform.tag == "Player"){
            isPickUp = false;
            for (int i = 0; i < collision.transform.childCount; i++)
            {
               string child = collision.transform.GetChild(i).gameObject.name;
                if(child == "plate" && collision.transform.GetChild(i).gameObject.transform.childCount == 0)
                {
                    plate = collision.transform.GetChild(i).gameObject;
                }
            }
        }
    }

    private void OnCollisionExit(Collision collision){
        isPickUp = true;
    }
}
