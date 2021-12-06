using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ParentForwardMovement : MonoBehaviour
{
    public float playerSpeed;
    void Start()
    {
        DOTween.Init();
    }
    private void Forward()
    {
        Vector3 forward = new Vector3(0, 0, playerSpeed*Time.deltaTime);
        transform.DOBlendableMoveBy(forward, 1f);
    }
    private void Update()
    {
        Forward(); 
    }
}
