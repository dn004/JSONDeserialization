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

    public void FireBall(float direction, float Speed)
    {
        rigidBody.AddForce(new Vector3(direction, 0, 0) * Speed, ForceMode.Impulse);
    }
}
