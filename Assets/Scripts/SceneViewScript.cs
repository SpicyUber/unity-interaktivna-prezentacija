using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SceneViewScript : MonoBehaviour
{
    public Vector3 LockPositionAt;
    public Transform AlignSceneViewTransform;
    public float Size;
    public bool IsOn;
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
        if (!IsOn) return; 

        transform.position = LockPositionAt;
        transform.rotation = Quaternion.identity;
        if (!Application.isPlaying)
        {
           // transform.position = SceneView.lastActiveSceneView.camera.transform.position + new Vector3(0f, 0, -SceneView.lastActiveSceneView.camera.transform.position.z);
         if(AlignSceneViewTransform!=null) SceneView.currentDrawingSceneView.AlignViewToObject(AlignSceneViewTransform);
            if (Size > 0) SceneView.currentDrawingSceneView.size = Size; else { SceneView.currentDrawingSceneView.size = 100; }
        }
    }
}
