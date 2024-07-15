using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMove : MonoBehaviour
{
    public int ballId;

    public Rigidbody rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public void FireBall(float ballDirection, float Speed)
    {
        rigidBody.AddForce(new Vector3(ballDirection, 0, 0) * Speed, ForceMode.Impulse);
    }
}
