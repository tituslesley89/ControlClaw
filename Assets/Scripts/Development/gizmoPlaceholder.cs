﻿using UnityEngine;
using System.Collections;

public class gizmoPlaceholder : MonoBehaviour {
    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position,0.5f);
    }
}
