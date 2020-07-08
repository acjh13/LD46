using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_GoHome : MonoBehaviour
{
    public GameObject homeLocation;
    public float speed = 3.0f;

    private GameObject angryEmoji, sickEmoji, badEmoji;
    private bool goingHome = false;
    private Vector2 homePos = new Vector2();

    void Start()
    {
        // set home position
        homePos = homeLocation.transform.position;
        angryEmoji = transform.GetChild(0).gameObject;
        sickEmoji = transform.GetChild(1).gameObject;
        badEmoji = transform.GetChild(2).gameObject;
    }

    public void SetGoingHome(bool status)
    {
        goingHome = status;
        angryEmoji.SetActive(status);

        if (sickEmoji.activeSelf)
        {
            sickEmoji.SetActive(false);
        }

        if (badEmoji.activeSelf)
        {
            badEmoji.SetActive(false);
        }
    }

    public bool GetGoingHome()
    {
        return goingHome;
    }

    void Update()
    {
        if (goingHome)
        {
            transform.position = Vector2.MoveTowards(transform.position, homePos, speed * Time.fixedDeltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "ShoutZone")
        {
            SetGoingHome(true);
        }
    }
}
