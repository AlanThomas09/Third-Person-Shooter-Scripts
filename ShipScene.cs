using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScene : MonoBehaviour
{
    public GameObject Cam1;
    public GameObject Cam2;
    public GameObject Barrier;
    public GameObject cv;
    public GameObject shipSpawn;
    public GameObject shipPrefab;

    void OnTriggerEnter(Collider other)
    {
        Cam1.SetActive(false);
        cv.SetActive(false);
        Cam2.SetActive(true);
        GameObject ship = Instantiate(shipPrefab, shipSpawn.transform.position, shipSpawn.transform.rotation);
        StartCoroutine(TheSequence());
    }

    IEnumerator TheSequence()
    {
        yield return new WaitForSeconds(10);
        cv.SetActive(true);
        Cam2.SetActive(false);
        Cam1.SetActive(true);
        Barrier.SetActive(false);
    }
}
