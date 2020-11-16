using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverText : MonoBehaviour
{
    private void OnDestroy()
    {
        var finishObj = GameObject.FindGameObjectWithTag("Finish");
        var meshRendererComponenet = finishObj.GetComponent<MeshRenderer>();
        if(meshRendererComponenet)
        {
            meshRendererComponenet.enabled = true;
        }
    }
}
