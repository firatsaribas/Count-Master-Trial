using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Spawn : MonoBehaviour
{
    public GameObject player;
    public GameObject pfFollower;
    private int positiveDifference;
    private int negativeDifference;



    public void SetPositiveDifference(int differenceOfrunners)
    {
        positiveDifference = differenceOfrunners;
    }
    public void SetNegativeDifference(int differenceOfrunners)
    {
        negativeDifference = differenceOfrunners;
    }
    public int GetCount()
    {
        return followerList.Count;
    }
   
    private List<Follower> followerList;
    void Start()
    {
        DOTween.Init();
        DOTween.SetTweensCapacity(7812,50);
    }
    private void Awake()
    {
        followerList = new List<Follower>() ;
    }

    void Update()
    {
        if (positiveDifference > 0)
        {
            for(int i=0; i<positiveDifference; i++)
            {
                GameObject tempGameObject = Instantiate(pfFollower, player.transform.position + new Vector3(0,0,-2), player.transform.rotation); ;
                Transform tempTrans = tempGameObject.GetComponent<Transform>();
                tempGameObject.AddComponent<Follower>();
                Follower runner = tempGameObject.GetComponent<Follower>();
                runner.GetEssentials(tempTrans, player, followerList.Count);
                
                //Follower runner = new Follower(tempTrans, player,followerList.Count);
                runner.PositionFixer();
                runner.CameraFixer();
                followerList.Add(runner);
            }
            positiveDifference = 0;
        }

        if( negativeDifference >0 )
        {
            for(int i=0; i < negativeDifference; i++)
            {
                int last = followerList.Count;
                Follower runnerr = followerList[last-1];
                runnerr.SelfDestruct();
                runnerr.CameraFixer();
                followerList.Remove(runnerr);
            }
            negativeDifference = 0;
        }
        HandleFollowerMove();
    }
    private void HandleFollowerMove()
    {
        for (int i = 0; i < followerList.Count; i++)
        {
            Follower runner = followerList[i];
            runner.Follow();
        }
    }

    public void RemoveFromList(int whichOne)
    {
        followerList.RemoveAt(whichOne);
        //Follower removed = followerList[whichOne];
        //followerList.Remove(removed);
        for (int i = whichOne; i < followerList.Count - 1; i++)
        {
            int y = i + 1;
            Follower tempFollower = followerList[y];
            followerList[i] = tempFollower;
        }
    }
    
}
