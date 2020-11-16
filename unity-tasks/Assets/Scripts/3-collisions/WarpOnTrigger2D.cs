using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpOnTrigger2D : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;

    [Tooltip("The position to warp the collided object (relative)")]
    [SerializeField] Vector3 warpTo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(triggeringTag))
        {
            collision.gameObject.transform.position += warpTo;
                
        }
    }
}
