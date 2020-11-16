using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldThePlayer : MonoBehaviour {
    [Tooltip("The number of seconds that the shield remains active")] [SerializeField] float duration;
    [Tooltip("Active shield object")] [SerializeField] GameObject activeShield;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            Debug.Log("Shield triggered by player");
            var destroyComponent = other.GetComponent<DestroyOnCollision2D>();
            if (destroyComponent) {
                destroyComponent.StartCoroutine(ShieldTemporarily(other.gameObject));
                // NOTE: If you just call "StartCoroutine", then it will not work, 
                //       since the present object is destroyed!
                Destroy(gameObject);  // Destroy the shield itself - prevent double-use
                
            }
        } else {
            Debug.Log("Shield triggered by "+other.name);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Shield triggered by player");
            var destroyComponent = other.gameObject.GetComponent<DestroyOnCollision2D>();
            if (destroyComponent)
            {
                destroyComponent.StartCoroutine(ShieldTemporarily(other.gameObject));
                // NOTE: If you just call "StartCoroutine", then it will not work, 
                //       since the present object is destroyed!
                Destroy(gameObject);  // Destroy the shield itself - prevent double-use

            }
        }
        else
        {
            Debug.Log("Shield triggered by " + other.gameObject.name);
        }
    }


    private IEnumerator ShieldTemporarily(GameObject obj) {
        var destroyComponent = obj.GetComponent<DestroyOnCollision2D>();
        var shieldImage = Instantiate(activeShield, obj.transform);
        var spriteRenderer = shieldImage.GetComponent<SpriteRenderer>();
        float startingAlpha = spriteRenderer.color.a;

        destroyComponent.enabled = false;
        for (float i = duration; i > 0; i--) {
           
            spriteRenderer.color = new Color(spriteRenderer.color.r,
                spriteRenderer.color.g,
                spriteRenderer.color.b,
                spriteRenderer.color.a - startingAlpha / 5);
            
            Debug.Log("Shield: " + i + " seconds remaining!");
            yield return new WaitForSeconds(1);
        }
        Debug.Log("Shield gone!");
        destroyComponent.enabled = true;
        Destroy(shieldImage);
    }
}
