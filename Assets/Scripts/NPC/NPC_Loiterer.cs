using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Adding this behaviour to a NPC should cause it to attempt to redo its previous behaviour
public class NPC_Loiterer : MonoBehaviour
{
    public Transform loiterTrans;
    public bool activated = true;
    public float speed = 0.25f;
    private GameObject badEmoji;
    void Start()
    {
        badEmoji = transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            transform.position = Vector2.MoveTowards(transform.position, loiterTrans.position, speed * Time.fixedDeltaTime);
            if (Vector2.Distance(transform.position, loiterTrans.position) < 0.5f)
            {
                activated = false;
                badEmoji.SetActive(false);
            }
        }
    }
}
