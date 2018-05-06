using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    public GameObject carPrefab;
    private Vector3 spawnPoint;
    private float colliderOnTime;

    private void Awake()
    {
        float random = Random.Range(75f, 120f);
        spawnPoint = new Vector3(random, transform.position.y, transform.position.z);
        if (!PhotonNetwork.connected)
        {
            PhotonNetwork.LoadLevel(0);
            return;
        }
        PhotonNetwork.Instantiate(carPrefab.name, spawnPoint, transform.rotation, 0);
    }
}
