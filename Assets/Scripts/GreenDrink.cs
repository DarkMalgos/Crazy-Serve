using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenDrink : MonoBehaviour
{
    [SerializeField]
    private GameObject PrefabBoissonVerte;

    [SerializeField]
    private GameObject PreparationBar;

    [SerializeField]
    private float healthPerSecond;

    protected GameObject RageBar;
    protected Healthbar RageBarScript;
    protected Image BgBar;
    protected Image FilledBar;

    private GameObject plate;

    private ServingScript servingScript;

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
        RageBar.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && !isPickUp && tag == "Machine Verte"){
            if(RageBarScript.health == 0)
            {
                RageBar.SetActive(true);
                RageBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 3, 0));
                 RageBarScript.regenerateHealth = true;
            }else if (RageBarScript.health == 100){
                if(servingScript.drinkOnPlate.Count < 3){
                    isPickUp = true;
                    RageBarScript.regenerateHealth = false;
                    RageBarScript.health = 0;
                    RageBar.SetActive(false);
                    GameObject BoissonVerte = Instantiate(PrefabBoissonVerte);
                    
                    if(servingScript.drinkOnPlate.Count == 0){
                        BoissonVerte.transform.SetParent(this.plate.transform.GetChild(0).gameObject.transform);
                        BoissonVerte.transform.localPosition = new Vector2(0,0);
                    }else if(servingScript.drinkOnPlate.Count == 1){
                        BoissonVerte.transform.SetParent(this.plate.transform.GetChild(1).gameObject.transform);
                        BoissonVerte.transform.localPosition = new Vector2(0,0);
                    }else if(servingScript.drinkOnPlate.Count == 2){
                        BoissonVerte.transform.SetParent(this.plate.transform.GetChild(2).gameObject.transform);
                        BoissonVerte.transform.localPosition = new Vector2(0,0);
                    }
                    servingScript.drinkOnPlate.Add(BoissonVerte);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.transform.tag == "Player"){
            isPickUp = false;
            for (int i = 0; i < collision.transform.childCount; i++)
            {
               string child = collision.transform.GetChild(i).gameObject.name;
                if(child == "plate")
                {
                    this.plate = collision.transform.GetChild(i).gameObject;
                    servingScript = plate.GetComponentInParent<ServingScript>();
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
