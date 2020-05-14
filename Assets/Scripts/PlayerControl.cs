using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private float Speed;

    [SerializeField]
    private float RotationSpeed;

    // Update is called once per frame
    void Update()
    {
        float DeltaSpeed = Speed * Time.deltaTime;
        float DeltaRot = RotationSpeed * Time.deltaTime;

        int Axe = 0;

        if (Input.GetKey(KeyCode.UpArrow))
            Axe = 1;

        if (Input.GetKey(KeyCode.DownArrow))
            Axe = -1;

        Vector3 CurrentSpeed = GetComponent<Rigidbody>().velocity;
        Vector3 MaxSpeed = Axe * DeltaSpeed * transform.forward;

        GetComponent<Rigidbody>().AddForce(MaxSpeed - CurrentSpeed);

        int Xaxe = 0;

        if (Input.GetKey(KeyCode.RightArrow))
            Xaxe = 1;

        if (Input.GetKey(KeyCode.LeftArrow))
            Xaxe = -1;

        transform.Rotate(new Vector3(0, Xaxe * DeltaRot, 0));

    }
}
