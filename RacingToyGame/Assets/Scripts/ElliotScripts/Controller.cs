using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    internal enum driveType
    {
        frontWheelDrive,
        rearWheelDrive,
        allWheelDrive
    }
    [SerializeField] private driveType drive;
    [Header("Variables")]
    public float KPH;
    public float breakPower;
    public float radius = 6;
    public float DownForceValue = 50;
    public int motorTorque = 100;
    public float steeringMax = 25;
    public float thrust = 1000f;
    private InputManager IM;
    private GameObject wheelMeshes, wheelColliders;
    private WheelCollider[] wheels = new WheelCollider[4];
    private GameObject[] wheelMesh = new GameObject[4];
    private GameObject centerOfMass;
    public Rigidbody rigidbody;

    [Header("DEBUG")]
    public float[] slip = new float[4];
    // Start is called before the first frame update

    void Start()
    {
        getObjects();
    }

    private void FixedUpdate()
    {
        addDownForce();
        animateWheels();
        moveVehicle();
        steerVehicle();
        getFriction();
    }

    private void moveVehicle()
    {
        float totalPower;
        if (drive == driveType.allWheelDrive)
        {
            for (int i = 0; i < wheels.Length; i++)
            {
                wheels[i].motorTorque = IM.vertical * (motorTorque / 4);
            }
        }
        else if (drive == driveType.rearWheelDrive)
        {
            for (int i = 2; i < wheels.Length; i++)
            {
                wheels[i].motorTorque = IM.vertical * (motorTorque / 2);
            }
        }
        else
        {
            for (int i = 0; i < wheels.Length - 2; i++)
            {
                wheels[i].motorTorque = IM.vertical * (motorTorque / 2);
            }
        }

        KPH = rigidbody.velocity.magnitude * 3.6f;


        if (IM.handbrake)
        {
            wheels[3].brakeTorque = wheels[2].brakeTorque = breakPower;
        }
        else
        {
            wheels[3].brakeTorque = wheels[2].brakeTorque = 0;
        }

        if (IM.boosting)
        {
            rigidbody.AddForce(Vector3.forward * thrust);
        }
    }

    private void steerVehicle()
    {
        if (IM.horizontal > 0)
        {
            wheels[0].steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (radius + (1.5f / 2))) * IM.horizontal;
            wheels[1].steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (radius + (1.5f / 2))) * IM.horizontal;
        }
        else if (IM.horizontal < 0)
        {
            wheels[0].steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (radius + (1.5f / 2))) * IM.horizontal;
            wheels[1].steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (radius + (1.5f / 2))) * IM.horizontal;

        }
        else
        {
            wheels[0].steerAngle = 0;
            wheels[1].steerAngle = 0;
        }
    }

    void animateWheels()
    {
        Vector3 wheelPosition = Vector3.zero;
        Quaternion wheelRotation = Quaternion.identity;

        for (int i = 0; i < 4; i++)
        {
            wheels[i].GetWorldPose(out wheelPosition, out wheelRotation);
            wheelMesh[i].transform.position = wheelPosition;
            wheelMesh[i].transform.rotation = wheelRotation;
        }
    }
    private void getObjects()
    {
        IM = GetComponent<InputManager>();
        rigidbody = GetComponent<Rigidbody>();
        wheelColliders = GameObject.Find("wheelColliders");
        wheelMeshes = GameObject.Find("wheelMeshes");
        wheels[0] = wheelColliders.transform.Find("0").gameObject.GetComponent<WheelCollider>();
        wheels[1] = wheelColliders.transform.Find("1").gameObject.GetComponent<WheelCollider>();
        wheels[2] = wheelColliders.transform.Find("2").gameObject.GetComponent<WheelCollider>();
        wheels[3] = wheelColliders.transform.Find("3").gameObject.GetComponent<WheelCollider>();


        wheelMesh[0] = wheelMeshes.transform.Find("0").gameObject;
        wheelMesh[1] = wheelMeshes.transform.Find("1").gameObject;
        wheelMesh[2] = wheelMeshes.transform.Find("2").gameObject;
        wheelMesh[3] = wheelMeshes.transform.Find("3").gameObject;

        centerOfMass = GameObject.Find("mass");
        rigidbody.centerOfMass = centerOfMass.transform.localPosition;
    }

    private void addDownForce()
    {
        rigidbody.AddForce(-transform.up * DownForceValue * rigidbody.velocity.magnitude);
    }

    private void getFriction()
    {
        for (int i = 0; i < wheels.Length; i++)
        {
            WheelHit wheelHit;
            wheels[i].GetGroundHit(out wheelHit);

            slip[i] = wheelHit.forwardSlip;
        }
    }

}


