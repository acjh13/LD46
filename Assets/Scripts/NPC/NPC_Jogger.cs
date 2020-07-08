using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Jogger : MonoBehaviour
{
    public bool activated = true;
    public float speed;
    public float fixedWaitDuration;
    public Transform[] waypoints;
    private float waitDuration;
    private int nextSpot;
    private GameObject badEmoji;
    
    void Start()
    {
        waitDuration = fixedWaitDuration;
        nextSpot = 0;
        badEmoji = transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[nextSpot].position, speed * Time.fixedDeltaTime);

            if (Vector2.Distance(transform.position, waypoints[nextSpot].position) < 0.2f)
            {
                if (waitDuration <= 0)
                {
                    ++nextSpot;
                    if (nextSpot == waypoints.Length)
                        nextSpot = 0;

                    waitDuration = fixedWaitDuration;
                    badEmoji.SetActive(false);
                }
                else
                {
                    waitDuration -= Time.deltaTime;
                }
            }
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "ShoutZone")
        {
            activated = false;
        }
    }
}
