using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleDrink : MonoBehaviour
{
    [SerializeField]
    private Dictionary<string,string> OrderManager;


    // Start is called before the first frame update
    void Start()
    {
        OrderManager = new Dictionary<string, string>();
    }

    public void AddOrder(string gameObjectName, string drinkTag){
        OrderManager.Add(gameObjectName,drinkTag);
        Debug.Log(gameObjectName);
        Debug.Log(drinkTag);

    }

    void update()
    {
        Debug.Log(OrderManager);
        
    }
}
