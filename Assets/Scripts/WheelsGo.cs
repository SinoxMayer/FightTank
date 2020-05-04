using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelsGo : MonoBehaviour
{
    private float forwardInput;
    private float horizantalInput;

    public WheelCollider whe;
    public GameObject wheel_car;

    public float torque = 100000;
    public float maxSteerAngle;


    // Start is called before the first frame update
    void Start()
    {
        whe = this.GetComponent<WheelCollider>();
    }


    void Go(float accel, float steer)
    {
        accel = Mathf.Clamp(accel, -1, 1);
        steer = Mathf.Clamp(steer, -1, 1) * maxSteerAngle;

        //delta time i cıkarabiliriz
        float thrustTorque = accel * torque * Time.deltaTime;
        whe.steerAngle = steer;
        whe.motorTorque = thrustTorque;

        Quaternion quat;
        Vector3 position;
        whe.GetWorldPose(out position, out quat);
        wheel_car.transform.position = position;
        wheel_car.transform.rotation = quat;

    }



    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        horizantalInput = Input.GetAxis("Horizontal");
        Go(forwardInput, horizantalInput);


    }
}
