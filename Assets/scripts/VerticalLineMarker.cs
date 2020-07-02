using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalLineMarker : MonoBehaviour { 

    public Color color;

    // This is to draw vertical marker lines in the editor.
    void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawLine((Vector2)transform.position - new Vector2(0, 1000), (Vector2)transform.position + new Vector2(0, 1000));
    }
}

