using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perspective : Sense {

    public int FieldOfView = 45;
    public int ViewDistance = 100;

    public Transform playerTrans;
    private Vector3 rayDirection;

	protected override void Initialize() {
        //playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
	}

    protected override void UpdateSense()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= detectionRate) DetectAspect();
    }

    void DetectAspect() {
        RaycastHit hit;
        rayDirection = playerTrans.position - transform.position;

        if((Vector3.Angle(rayDirection, transform.forward)) < FieldOfView)
        {
            if(Physics.Raycast(transform.position, rayDirection, out hit, ViewDistance))
            {
                Aspect aspect = hit.collider.GetComponent<Aspect>();
                if(aspect!=null)
                    if (aspect.aspectName == aspectName) print("Enemy Detected");
            }
        }
	}

    void OnDrawGizmos()
    {
        if (playerTrans == null) return;

        Debug.DrawLine(transform.position, playerTrans.position, Color.red);

        Vector3 frontRayPoint = transform.position + (transform.forward * ViewDistance);
        Vector3 leftRayPoint = frontRayPoint;
        leftRayPoint.x += FieldOfView * 0.5f;

        Vector3 rightRayPoint = frontRayPoint;
        rightRayPoint.x -= FieldOfView * 0.5f;

        Debug.DrawLine(transform.position, frontRayPoint, Color.green);
        Debug.DrawLine(transform.position, leftRayPoint, Color.green);
        Debug.DrawLine(transform.position, rightRayPoint, Color.green);
    }
}
