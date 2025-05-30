using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SceneViewScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying)
        {
            transform.position = SceneView.lastActiveSceneView.camera.transform.position + new Vector3(0f, 0, -SceneView.lastActiveSceneView.camera.transform.position.z);

        }
    }
}
