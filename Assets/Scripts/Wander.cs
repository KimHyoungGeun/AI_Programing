using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour {

    private Vector3 tarPos;

    private float movementSpeed = 5f;
    private float rotSpeed = 2f;
    private float minX, maxX, minZ, maxZ;

    void Start()
    {
        minX = -45f;
        maxX = 45f;

        minZ = -45f;
        maxZ = 45f;

        GetNextPosition();
    }

    void Update () {
        if (Vector3.Distance(tarPos, transform.position) <= 5f)
            GetNextPosition();
        Quaternion tarRot = Quaternion.LookRotation(tarPos - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, tarRot, rotSpeed * Time.deltaTime);
        transform.Translate(new Vector3(0, 0, movementSpeed * Time.deltaTime));
	}

    void GetNextPosition()
    {
        tarPos = new Vector3(Random.Range(minX, maxX), 0.5f, Random.Range(minZ, maxZ));
    }
}
