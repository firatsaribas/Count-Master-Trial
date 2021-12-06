using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 firstPos;
    private Vector3 finalPos;
    private Vector3 dif;
    public float laneSpeed;
    //private Vector3 playerPosFix = new Vector3(0, 1.35f, 0);



    private void PositionInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Input.mousePosition;
            pos.z = 10;
            firstPos = Camera.main.ScreenToViewportPoint(pos);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 pos = Input.mousePosition;
            pos.z = 10;
            finalPos = Camera.main.ScreenToViewportPoint(pos);
            Vector3 change = finalPos - firstPos;
            dif += new Vector3(change.x, 0, 0) * Time.deltaTime * laneSpeed;
            dif.x = Mathf.Clamp(dif.x, -8.5f, +8.5f);
            transform.localPosition = dif /*+ playerPosFix*/;
            firstPos = finalPos;
        }
    }

    
    private void Update()
    {
        PositionInput();
    }
    
}
