using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinOnCollision : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(triggeringTag))
        {
            var meshRendererComponenet = GetComponent<MeshRenderer>();
            meshRendererComponenet.enabled = true;
        }
    }
}
