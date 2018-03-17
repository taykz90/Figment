using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSeam : MonoBehaviour {

    void Awake()
    {
        GameObject A = GameObject.FindGameObjectWithTag("seam");
        Destroy(A);
    }
}