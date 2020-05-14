using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngerScript : MonoBehaviour
{

    [SerializeField]
    private GameObject BagarreAnimation;

    protected int angerZone = 0;
    private List<GameObject> memberZone = new List<GameObject>();
    private List<Healthbar> memberRageBar = new List<Healthbar>();

    private void Update()
    {
        for (int i=0; i < memberRageBar.Count; i++)
        {
            Healthbar rageBar = memberRageBar[i];

            if (angerZone < 1 && rageBar.health == 100)
            {
                ++angerZone;
                memberRageBar.RemoveAt(i);
                --i;
            } else if (angerZone == 1 && rageBar.health == 100)
            {
                angerZone = 0;
                StartWar();
                break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pnj")
        {
            GameObject pnj = other.gameObject;
            memberZone.Add(pnj);
            memberRageBar.Add(pnj.GetComponentInParent<BikerAngerScript>().RageBarScript);
        }
    }

    private void StartWar()
    {
        memberRageBar.Clear();
        GameObject fight = Instantiate(BagarreAnimation, transform);
        fight.transform.localPosition = new Vector3(4, 0, -2);
        Destroy(fight, 10);
        resetAngerZone();
    }

    private void resetAngerZone()
    {
        foreach(GameObject member in memberZone)
            member.GetComponentInParent<BikerAngerScript>().Reset();
    }
}
