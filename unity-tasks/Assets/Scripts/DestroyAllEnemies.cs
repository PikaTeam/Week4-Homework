using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAllEnemies : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var collider = collision.gameObject;

        if (collider.tag.Equals("Player"))
        {
            DestroyAllEnemeies();
        }
    }

    private void DestroyAllEnemeies()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (var enemy in enemies)
        {
            Destroy(enemy);
        }
    }

}
