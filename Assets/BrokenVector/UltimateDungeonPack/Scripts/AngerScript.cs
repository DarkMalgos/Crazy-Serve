using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AngerScript : MonoBehaviour
{

    [SerializeField]
    protected int CurrentAnger;

    protected int MaxAnger;

    // Start is called before the first frame update
    void Start()
    {
        CurrentAnger = 0;
    }


    public virtual void updateAnger(int nb)
    {
        CurrentAnger += nb;

        if(CurrentAnger >= 100)
        {

        }
    }

    public abstract void Anger();
}
