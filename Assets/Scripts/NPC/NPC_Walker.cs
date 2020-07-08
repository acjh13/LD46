using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Walker : MonoBehaviour
{
    public bool activated = true;
    public float speed;
    public float fixedWaitDuration;
    public float minX, maxX, minY, maxY;
    public Transform movePos;
    private float waitDuration;    
    private GameObject badEmoji;

    void Start()
    {
        waitDuration = fixedWaitDuration;
        movePos.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        badEmoji = transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            transform.position = Vector2.MoveTowards(transform.position, movePos.position, speed * Time.fixedDeltaTime);

            if (Vector2.Distance(transform.position, movePos.position) < 0.2f)
            {
                if (waitDuration <= 0)
                {
                    movePos.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
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
