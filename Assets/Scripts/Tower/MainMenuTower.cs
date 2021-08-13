using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuTower : MonoBehaviour
{
    [SerializeField] private GameObject Head;
    [SerializeField] private Camera cam;

    void Update()
    {
        var mousePos = Input.mousePosition;
        var wantedPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10));

        Head.GetComponent<Transform>().LookAt(wantedPos);
        //Vector3 mousePos = Input.mousePosition;

        //Head.GetComponent<Transform>().LookAt(cam.ScreenToWorldPoint(mousePos, Camera.MonoOrStereoscopicEye.Mono));
    }
}

