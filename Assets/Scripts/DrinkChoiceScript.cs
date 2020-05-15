using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrinkChoiceScript : MonoBehaviour
{
    private BikerAngerScript BikerAnger;

    [SerializeField]
    private float DeltaTimeOrder;

    [SerializeField]
    private int PrctRedDrink = 20;

    [SerializeField]
    private int PrctBlueDrink = 50;

    [SerializeField]
    private GameObject DrinkChoicePrefab;

    [SerializeField]
    private GameObject DrinkManager;

    private HandleDrink DrinkHandler;

    private GameObject DrinkChoiceColor;

    private Image DrinkColor;

    private int DrinkOrder;

    private float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        DeltaTimeOrder = Random.Range(10,120);
        BikerAnger = GetComponentInParent<BikerAngerScript>();
        DrinkChoiceColor = Instantiate(DrinkChoicePrefab, FindObjectOfType<Canvas>().transform);
        DrinkColor = DrinkChoiceColor.GetComponentInChildren<Image>();
        DrinkHandler = DrinkManager.GetComponent<HandleDrink>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(!BikerAnger.order && time > DeltaTimeOrder)
        {
            DrinkChoiceColor.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0.2f, 4, -0.5f));
            DrinkOrder = Random.Range(1,100);
            if(DrinkOrder <= PrctRedDrink){
                DrinkColor.color = Color.red;
                DrinkHandler.AddOrder(this.transform.name,"Boisson Rouge");
            }else if(DrinkOrder > PrctRedDrink && DrinkOrder <= PrctBlueDrink){
                DrinkColor.color = Color.blue;
                DrinkHandler.AddOrder(this.transform.name,"Boisson Bleue");
            }else if(DrinkOrder > PrctBlueDrink){
                DrinkColor.color = Color.green;
                DrinkHandler.AddOrder(this.transform.name,"Boisson Verte");
            }
            BikerAnger.order = true;
            time = 0;
        }        
    }
}
