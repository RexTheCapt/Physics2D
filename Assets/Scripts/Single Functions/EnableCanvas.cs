using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCanvas : MonoBehaviour
{
    public GameObject CanvasGameObject;

    void Start()
    {
        CanvasGameObject.SetActive(true);
    }
}
