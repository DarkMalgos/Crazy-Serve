using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngerScript : MonoBehaviour
{

    [SerializeField]
    private GameObject BagarreAnimation;

    protected int angerZone = 0;

    private void Update()
    {
        Debug.Log("update anger zone " + angerZone);
        if (angerZone > 1)
        {
            StartWar();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("tag " + other.gameObject.tag);
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("tag " + other.gameObject.tag);
        if (other.gameObject.tag == "Pnj")
        {
            Debug.Log("i'm a pnj");
            if (other.gameObject.GetComponent<BikerAngerScript>().GetHealthbar().health == 100)
            {
                ++angerZone;
                Debug.Log("+1 anger zone " + angerZone);
            }
        }
    }

    private void StartWar()
    {
        Instantiate(BagarreAnimation);
    }
}
