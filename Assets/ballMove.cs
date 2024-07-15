using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMove : MonoBehaviour
{
    public int ballId;

    private Rigidbody rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public void FireBall(float ballDirection, float Speed)
    {
        rigidBody.AddForce(new Vector3(ballDirection, 0, 0) * Speed, ForceMode.Impulse);
    }
}
