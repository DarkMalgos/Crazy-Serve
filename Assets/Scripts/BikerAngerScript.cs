using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BikerAngerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabAngerBar;
    public bool order;
    public float ragePerSecond = 0.75F;

    protected GameObject RageBar;
    public Healthbar RageBarScript;
    protected Image BgBar;
    protected Image FilledBar;


    private void Start()
    {
        RageBar = Instantiate(prefabAngerBar, FindObjectOfType<Canvas>().transform);
        RageBarScript = RageBar.GetComponent<Healthbar>();
        RageBarScript.health = 0;
        RageBarScript.regenerateHealth = false;
        RageBarScript.healthPerSecond = ragePerSecond;
        BgBar = RageBar.GetComponentInChildren<Image>();
        FilledBar = BgBar.GetComponentInChildren<Image>();
        Debug.Log(RageBar.transform.position);
        Debug.Log(BgBar.transform.position);
        Debug.Log(FilledBar.transform.position);
    }

    public Healthbar GetHealthbar()
    {
        return RageBarScript;
    }

    private void Update()
    {
        RageBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 3, 0));
        if (order)
        {
            Debug.Log(RageBarScript.healthPerSecond);
            RageBarScript.regenerateHealth = true;
            RageBarScript.healthPerSecond = ragePerSecond;
        }
    }

    public void Reset()
    {
        Debug.Log("hello");
        order = false;
        RageBarScript.regenerateHealth = false;
        RageBarScript.health = 0;
        Debug.Log(RageBarScript.health);
    }
}
