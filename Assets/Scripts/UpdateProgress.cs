using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateProgress : MonoBehaviour
{
    private GameManager gm;
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "NPC")
        {
            other.gameObject.SetActive(false);
            gm.NPCSentHome();
        }
    }
}
