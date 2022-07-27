using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController2 : MonoBehaviour
{
    public GameObject Player;
    private Controller RR;
    public GameObject cameraConstraint;
    public GameObject cameraLookAt;
    public GameObject Child;
    public float speed = 0;
    public float defaltFOV = 0, desireFOV = 0;
    [Range(0, 2)] public float smothTime = 0;
    public Camera gameCam;

    // Start is called before the first frame update
    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        RR = Player.GetComponent<Controller>();
        defaltFOV = gameCam.fieldOfView;
    }

    private void FixedUpdate()
    {
        follow();
        boostFOV();

    }

    private void follow()
    {
        if (speed <= 23)
            speed = Mathf.Lerp(speed, RR.KPH / 2, Time.deltaTime);
        else
            speed = 23;

        gameObject.transform.position = Vector3.Lerp(transform.position, cameraConstraint.transform.position, Time.deltaTime * speed);
        gameObject.transform.LookAt(cameraLookAt.gameObject.transform.position);
    }

    private void boostFOV()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            gameCam.fieldOfView = Mathf.Lerp(gameCam.fieldOfView, desireFOV, Time.deltaTime * smothTime);
        }
        else
            gameCam.fieldOfView = Mathf.Lerp(gameCam.fieldOfView, defaltFOV, Time.deltaTime * smothTime);
    }
}