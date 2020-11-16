using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestorySelfOnCollision2D : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == triggeringTag && enabled)
        {
            Debug.Log("SHILDED!");
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var other = collision.gameObject;

        if (other.tag == triggeringTag && enabled)
        {
            Debug.Log("SHILDED!");
            Destroy(this.gameObject);
        }
    }
}
