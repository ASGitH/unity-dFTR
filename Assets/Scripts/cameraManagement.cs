using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraManagement : MonoBehaviour
{
    private int selectedCamera;

    public int startingCamera;

    public List<Camera> cameraList = new List<Camera>();

    void Start()
    {
        for(int sJ = 0; sJ < cameraList.Count; sJ++)
        {
            if(sJ != startingCamera) { cameraList[sJ].gameObject.SetActive(false); }
            else { cameraList[sJ].gameObject.SetActive(true); }
        }

        selectedCamera = startingCamera;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            cameraList[selectedCamera].gameObject.SetActive(false);

            if (selectedCamera < cameraList.Count - 1) { selectedCamera += 1;             }
            else { selectedCamera = 0; }

            cameraList[selectedCamera].gameObject.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            cameraList[selectedCamera].gameObject.SetActive(false);

            if (selectedCamera != 0) { selectedCamera -= 1; }
            else { selectedCamera = cameraList.Count - 1; }

            cameraList[selectedCamera].gameObject.SetActive(true);
        }
    }
}