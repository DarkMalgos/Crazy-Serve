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
    private float DeltaTimeCooldown = 45;

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
    private GameObject AngerBar;

    private Image DrinkColor;

    private int DrinkOrder;

    private float time = 0;

    public string colorOrder;

    // Start is called before the first frame update
    void Start()
    {
        DeltaTimeOrder = Random.Range(10,120);
        BikerAnger = GetComponentInParent<BikerAngerScript>();
        AngerBar = BikerAnger.GetBar();
        DrinkHandler = DrinkManager.GetComponentInChildren<HandleDrink>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(!BikerAnger.order && time > DeltaTimeOrder)
        {
            DrinkChoiceColor = Instantiate(DrinkChoicePrefab, FindObjectOfType<Canvas>().transform);
            DrinkColor = DrinkChoiceColor.GetComponentInChildren<Image>();
            DrinkChoiceColor.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(.5F, 3, 0));
            DrinkOrder = Random.Range(1,100);
            if(DrinkOrder <= PrctRedDrink){
                DrinkColor.color = Color.red;
                colorOrder = "red";
                DrinkHandler.AddOrder(transform.name,"Boisson Rouge");
            } else if(DrinkOrder <= PrctRedDrink && DrinkOrder <= (PrctBlueDrink + PrctRedDrink)) {
                DrinkColor.color = Color.blue;
                colorOrder = "blue";
                DrinkHandler.AddOrder(transform.name,"Boisson Bleue");
            } else {
                DrinkColor.color = Color.green;
                colorOrder = "green";
                DrinkHandler.AddOrder(transform.name,"Boisson Verte");
            }
            BikerAnger.order = true;
            time = 0;
        }        
    }

    public void Reset()
    {
        BikerAnger.order = false;
        time = -1 * DeltaTimeCooldown;
        DestroyImmediate(DrinkChoiceColor);
        DestroyImmediate(DrinkColor);
        colorOrder = null;
    }
}
