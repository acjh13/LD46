using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackLogic : MonoBehaviour
{
    public BoxCollider2D shoutZone;
    private Transform shoutTransform;
    private Vector3 upVec = new Vector3(0, 1.5f, 0);
    private Vector3 downVec = new Vector3(0, -1.5f, 0);
    private Vector3 leftVec = new Vector3(-1.5f, 0, 0);
    private Vector3 rightVec = new Vector3(1.5f, 0, 0);

    void Start()
    {
        shoutTransform = shoutZone.gameObject.GetComponent<Transform>();
    }

    public void Shout(bool activate, facingDirection dir)
    {
        if (activate)
        {
            switch(dir)
            {
                case facingDirection.Up:
                    shoutTransform.localPosition = upVec;
                    break;

                case facingDirection.Down:
                    shoutTransform.localPosition = downVec;
                    break;
                    
                case facingDirection.Left:
                    shoutTransform.localPosition = leftVec;
                    break;

                case facingDirection.Right:
                    shoutTransform.localPosition = rightVec;
                    break;

                default:
                    break;
            }
            
            shoutZone.gameObject.SetActive(true);
        }
        else
        {
            shoutZone.gameObject.SetActive(false);
        }
    }
}
