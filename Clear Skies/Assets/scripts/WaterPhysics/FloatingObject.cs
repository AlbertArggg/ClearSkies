using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    public Rigidbody RigidBody;
    public float depthBeforeSubmerged;
    public float displacementAmount = 3f;
    public int FloaterBodyCount = 4;
    public float waterDrag = 0.99f;
    public float waterAngularDrag = 0.5f;
    

    private void FixedUpdate()
    {
        var position = transform.position;
        float waveHeight = WaveManager.instance.GetWaveHeight(position.x, position.z);
        
        RigidBody.AddForceAtPosition(Physics.gravity / FloaterBodyCount, position, ForceMode.Acceleration);
        
        if (transform.position.y < waveHeight)
        {
            float displacementMultiplier = Mathf.Clamp01((waveHeight-position.y) / depthBeforeSubmerged) * displacementAmount;
            RigidBody.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f), position, ForceMode.Acceleration);
            RigidBody.AddForce(-RigidBody.velocity * (displacementMultiplier * waterDrag * Time.fixedDeltaTime), ForceMode.VelocityChange);
            RigidBody.AddTorque(-RigidBody.velocity * (displacementMultiplier * waterAngularDrag * Time.fixedDeltaTime), ForceMode.VelocityChange);
        }
    }
}
