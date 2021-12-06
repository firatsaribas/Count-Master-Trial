using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Obstacle : MonoBehaviour
{
    public Spawn gameHandler;
    private List<Follower> followerTempList;
    //public Follower hitRunner;

    private void Awake()
    {
        followerTempList = new List<Follower>();
    }

    public void Update()
    {
        gameObject.transform.Rotate(Vector3.up * Time.deltaTime * 150f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Follower")
        {
            Debug.Log("yok ett ");
            Follower tempRunner = other.gameObject.GetComponent<Follower>();
            tempRunner.SelfDestruct();
            tempRunner.DOKill();
            //int removedNumber = tempRunner.GetNumber();
            //gameHandler.RemoveFromList(removedNumber);
        }
        
    }
}
