using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LoadingBarScript : MonoBehaviour
{
    [SerializeField]
    public Image LoadingBar;

    [SerializeField]
    public float MaxTime;

    public float TimeLeft;

    public GameObject BoissonReady;

    // Update is called once per frame
    void Update()
    {
        if(TimeLeft > 1){
            TimeLeft += Time.deltaTime;
            LoadingBar.fillAmount = TimeLeft / MaxTime;
        }else {
            BoissonReady.SetActive(true);
            LoadingBar.enabled = false;
        }
    }
}
