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
        Debug.Log("anger zone " + angerZone);
        if (angerZone > 1)
        {
            StartWar();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "pnj")
        {
            if (other.gameObject.GetComponent<BikerAngerScript>().GetHealthbar().health == 100)
            {
                ++angerZone;
            }
        }
    }

    private void StartWar()
    {
        Instantiate(BagarreAnimation);
    }
}
