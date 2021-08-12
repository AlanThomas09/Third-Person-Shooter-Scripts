using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSequence : MonoBehaviour
{
    public GameObject Cam1;
    public GameObject Cam2;
    public GameObject Barrier;
    public GameObject cv;

    public int waitTime = 10;

    void Start()
    {
        StartCoroutine(TheSequence());
    }

    IEnumerator TheSequence()
    {
        yield return new WaitForSeconds(waitTime);
        cv.SetActive(true);
        Cam2.SetActive(true);
        Cam1.SetActive(false);
        Barrier.SetActive(false);
    }
}
