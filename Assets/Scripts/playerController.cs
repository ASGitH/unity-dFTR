using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class playerController : MonoBehaviour
{
    #region private
    private float vehicleSpeed;

    private Vector3 movementVector;
    #endregion

    #region public
    public float turningRadius;

    public GameObject frontLeftTire, frontRightTire, rearLeftTire, rearRightTire;

    public TextMeshProUGUI speedometerTMP;
    #endregion

    void Start()
    {
        // turningRadius = 0f;

        vehicleSpeed = 0f;

        speedometerTMP.text = vehicleSpeed.ToString();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            frontLeftTire.transform.GetChild(0).Rotate(-8f, 0f, 0f);
            frontRightTire.transform.GetChild(0).Rotate(-8f, 0f, 0f);

            vehicleSpeed += .1f * Time.deltaTime;

            if (vehicleSpeed >= /* 1f */ .5f) { vehicleSpeed = /* .99f */ .49f; }
        }
        else
        {
            if (Input.GetKey(KeyCode.S)) { vehicleSpeed -= .4f * Time.deltaTime; }
            else { vehicleSpeed -= /* .1f */ .075f * Time.deltaTime; }

            if (vehicleSpeed <= 0f) { vehicleSpeed = 0f; }
        }

        // Debug.Log(vehicleSpeed);

        transform.position += transform.TransformDirection(Vector3.back) * vehicleSpeed;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (turningRadius - 1f > -22f)
            {
                // frontLeftTire.transform.Rotate(0f, /* -128f */ -256f * Time.deltaTime, 0f);

                frontLeftTire.transform.Rotate(0f, -1f, 0f);
                frontRightTire.transform.Rotate(0f, -1f, 0f);

                turningRadius -= 1f;
            }

            if (vehicleSpeed > 0f) { transform.Rotate(0f, -2f, 0f); }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (turningRadius + 1f < 22f)
            {
                frontLeftTire.transform.Rotate(0f, 1f, 0f);
                frontRightTire.transform.Rotate(0f, 1f, 0f);

                turningRadius += 1f;
            }

            if (vehicleSpeed > 0f) { transform.Rotate(0f, 2f, 0f); }
        }
        else
        {
            if (turningRadius > 0f)
            {
                frontLeftTire.transform.Rotate(0f, -1f, 0f);
                frontRightTire.transform.Rotate(0f, -1f, 0f);

                turningRadius -= 1f;
            }
            else if(turningRadius < 0f)
            {
                frontLeftTire.transform.Rotate(0f, +1f, 0f);
                frontRightTire.transform.Rotate(0f, +1f, 0f);

                turningRadius += 1f;
            }
            else { turningRadius = 0f; }
        }

        if(vehicleSpeed > 0f)
        {
            frontLeftTire.transform.GetChild(0).Rotate(-8f, 0f, 0f);
            frontRightTire.transform.GetChild(0).Rotate(-8f, 0f, 0f);
        }

        speedometerTMP.text = vehicleSpeed.ToString();
    }
}
