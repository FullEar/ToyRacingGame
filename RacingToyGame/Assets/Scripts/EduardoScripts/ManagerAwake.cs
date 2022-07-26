using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerAwake : MonoBehaviour
{
    public GameObject toRotate;
    public GunList gunlist;
    public float rotateSpeed;
    public int vehiclePointer = 0;
    public GameObject spawnPoint;

    private void Awake()
    {
        PlayerPrefs.SetInt("pointer", vehiclePointer);

        vehiclePointer = PlayerPrefs.GetInt("pointer");

        GameObject childObject = Instantiate(gunlist.vehicles[vehiclePointer], spawnPoint.transform.position, Quaternion.identity) as GameObject;
        childObject.transform.parent = toRotate.transform;

    }
    private void FixedUpdate()
    {
        toRotate.transform.Rotate(spawnPoint.transform.position * rotateSpeed * Time.deltaTime);
    }

    public void rightButton()
    {
        if (vehiclePointer < gunlist.vehicles.Length - 1)
        {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            vehiclePointer++;
            PlayerPrefs.SetInt("pointer", vehiclePointer);
            GameObject childObject = Instantiate(gunlist.vehicles[vehiclePointer], spawnPoint.transform.position, Quaternion.identity) as GameObject;
            childObject.transform.parent = toRotate.transform;
        }
    }

    public void leftButton()
    {
        if (vehiclePointer > 0)
        {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            vehiclePointer--;
            PlayerPrefs.SetInt("pointer", vehiclePointer);
            GameObject childObject = Instantiate(gunlist.vehicles[vehiclePointer], spawnPoint.transform.position, Quaternion.identity) as GameObject;
            childObject.transform.parent = toRotate.transform;
        }
    }

    public void StarGameButton()
    {
        SceneManager.LoadScene("FirstLevel");
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
