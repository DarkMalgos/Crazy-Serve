using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleDrink : MonoBehaviour
{
    public Dictionary<string,string> OrderManager = new Dictionary<string, string>();

    public void AddOrder(string gameObjectName, string drinkTag){
        Debug.Log(OrderManager);
        this.OrderManager.Add(gameObjectName,drinkTag);
        Debug.Log(gameObjectName);
        Debug.Log(drinkTag);
    }

    void update()
    {
        Debug.Log(OrderManager);  
    }
}
