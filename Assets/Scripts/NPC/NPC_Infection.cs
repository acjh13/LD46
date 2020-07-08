using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Infection : MonoBehaviour
{
    public InfectionBar infectionBar;
    public List<int> overlappingIds; 
    private GameObject infectEmoji;
    private bool infecting = false;
    private NPC_GoHome goHomeScript = null;

    void Start()
    {
        infectionBar = GameObject.FindGameObjectWithTag("InfectionBar").GetComponent<InfectionBar>();
        infectEmoji = transform.GetChild(1).gameObject;
        goHomeScript = GetComponent<NPC_GoHome>();
        overlappingIds = new List<int>();
    }

    void Update()
    {
        if (infecting && !goHomeScript.GetGoingHome())
            infectionBar.IncrementInfectionLevel();
    }

    void SetInfectionStatus(bool status)
    {
        infecting = status;
        infectEmoji.SetActive(status);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "NPC")
        {
            if (!overlappingIds.Contains(other.GetInstanceID()))
                overlappingIds.Add(other.GetInstanceID());

            SetInfectionStatus(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "NPC")
        {
            overlappingIds.Remove(other.GetInstanceID());

            if (overlappingIds.Count == 0)
                SetInfectionStatus(false);
        }
    }
}
