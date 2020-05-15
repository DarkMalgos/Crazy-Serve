using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RedDrink : MonoBehaviour
{
    [SerializeField]
    private GameObject PrefabBoissonRouge;

    [SerializeField]
    private GameObject PreparationBar;

    [SerializeField]
    private float healthPerSecond;

    protected GameObject RageBar;
    protected Healthbar RageBarScript;
    protected Image BgBar;
    protected Image FilledBar;


    private GameObject plate;

    private bool isPickUp = true;

        void Start()
    {
        RageBar = Instantiate(PreparationBar, FindObjectOfType<Canvas>().transform);
        RageBarScript = RageBar.GetComponent<Healthbar>();
        RageBarScript.health = 0;
        RageBarScript.regenerateHealth = false;
        RageBarScript.healthPerSecond = healthPerSecond;
        RageBarScript.lowHealthColor = new Color(0.35f, 1f, 0.35f);
        RageBarScript.highHealthColor = new Color(1f, 0.259434f, 0.259434f); 
        BgBar = RageBar.GetComponentInChildren<Image>();
        FilledBar = BgBar.GetComponentInChildren<Image>();
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && !isPickUp && tag == "Machine Rouge"){
            if(RageBarScript.health == 0){
                 RageBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 3, 0));
                 RageBarScript.regenerateHealth = true;
            }else if (RageBarScript.health == 100){
             isPickUp = true;
             GameObject BoissonRouge = Instantiate(PrefabBoissonRouge);
             BoissonRouge.transform.SetParent(this.plate.transform);
             BoissonRouge.transform.localPosition = new Vector2(0.3f,0);
             RageBarScript.regenerateHealth = false;
             RageBarScript.health = 0;
            }       
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
                }
            }
        }
    }

    private void OnCollisionExit(Collision collision){
        isPickUp = true;
    }

    
    public Healthbar GetHealthbar()
    {
        return RageBarScript;
    }
}
