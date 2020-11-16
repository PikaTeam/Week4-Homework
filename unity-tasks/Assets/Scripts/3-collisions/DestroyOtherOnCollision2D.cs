﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOtherOnCollision2D : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;


    private void OnTriggerEnter2D(Collider2D other)
    {

        if ((triggeringTag.Equals("ALL") || other.gameObject.tag.Equals(triggeringTag)) && enabled)
        {
            Destroy(other.gameObject);
        }
    }



}
