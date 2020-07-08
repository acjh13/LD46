using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Stubborn : MonoBehaviour
{
    public float speed = 0.25f;
    public float fixedResetDuration = 1.0f;

    public bool isLoiterer = false;
    public bool isJogger = false;
    public bool isWalker = false;
    private float resetDuration;
    private NPC_GoHome gohomeScript;

    private NPC_Jogger jogScript = null;
    private NPC_Walker walkScript = null;
    private NPC_Loiterer loiterScript = null;
    private GameObject badEmoji;

    void Start()
    {
        resetDuration = fixedResetDuration;
        gohomeScript = GetComponent<NPC_GoHome>();
        badEmoji = transform.GetChild(2).gameObject;

        if (isLoiterer)
        {
            // just returns to their orig position
            loiterScript = GetComponent<NPC_Loiterer>();
        }
        else if (isWalker)
        {
            // returns to their wandering pattern
            walkScript = GetComponent<NPC_Walker>();
        }
        else if (isJogger)
        {
            // returns to their jogging pattern
            jogScript = GetComponent<NPC_Jogger>();
        }
    }

    void ResetBehaviour()
    {
        gohomeScript.SetGoingHome(false);
        // reset whatever behaviour they had
        if (isLoiterer)
        {
            // just returns to their orig position
            loiterScript.activated = true;
        }
        else if (isWalker)
        {
            // returns to their wandering pattern
            walkScript.activated = true;
        }
        else if (isJogger)
        {
            // returns to their jogging pattern
            jogScript.activated = true;
        }
        badEmoji.SetActive(true);
    }

    void Update()
    {
        // Will only run if the NPC is going home
        if (gohomeScript.GetGoingHome())
        {
            if (resetDuration <= 0)
            {
                ResetBehaviour();
                resetDuration = fixedResetDuration;
            }
            else
            {
                resetDuration -= Time.deltaTime;
            }
        }
    }
}
