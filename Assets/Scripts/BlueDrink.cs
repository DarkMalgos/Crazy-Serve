using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueDrink : MonoBehaviour
{
    [SerializeField]
    private GameObject PrefabBoissonBleue;

    private GameObject plate;

    private bool isPickUp = true;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && !isPickUp && tag == "Machine Bleue"){
                    isPickUp = true;
                    GameObject BoissonBleue = Instantiate(PrefabBoissonBleue);
                    Debug.Log(this.plate);
                    BoissonBleue.transform.SetParent(this.plate.transform);    
                    BoissonBleue.transform.localPosition = new Vector2(0,0);  
        }
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.transform.tag == "Player"){
            isPickUp = false;
            for (int i = 0; i < collision.transform.childCount; i++)
            {
                string child = collision.transform.GetChild(i).gameObject.name;
                if(child == "plate" && collision.transform.GetChild(i).gameObject.transform.childCount <= 3)
                {
                    this.plate = collision.transform.GetChild(i).gameObject;
                    Debug.Log(this.plate);
                }
            }
        }
    }

    private void OnCollisionExit(Collision collision){
        isPickUp = true;
    }
}
