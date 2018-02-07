using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sense : MonoBehaviour {

    public bool bDebug = true;
    public Aspect.aspect aspectName = Aspect.aspect.Enemy;
    public float detectionRate = 1f;

    protected float elapsedTime = 0f;

    protected virtual void Initialize() { }
    protected virtual void UpdateSense() { }

    void Start () {
        elapsedTime = 0f;
        Initialize();
	}
	
	void Update () {
        UpdateSense();
	}
}
