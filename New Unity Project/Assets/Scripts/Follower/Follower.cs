using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Follower : MonoBehaviour
{
    private Vector3 positionFix = new Vector3(0, 0, 0);
    private int positionNum;
    private GameObject followedPlayer;
    private Vector3 relativeSpawnPosition;
    private Transform followerr;
  

    public void GetEssentials(Transform pffollower, GameObject player, int number)
    {
        this.followedPlayer = player;
        this.followerr = pffollower;
        this.positionNum = number;
    }

    //public Follower(Transform pffollower, GameObject player, int number)
    //{
    //    TRYED TO DO WITH CONSTRUCTORS BUT FAILED IN THE OBSTACLE PART
    //    this.followedPlayer = player;
    //    this.followerr = pffollower;
    //    this.positionNum = number;
    //}
    public void CameraFixer()
    {
        int multiplier = positionNum / 7;
        Camera.main.transform.DOLocalMove(new Vector3(0, 7.24f + multiplier, -8.09f - multiplier * 2), .5f);
    }
    public void PositionFixer()
    {

        int multiplier = positionNum / 7;
        positionFix.z = -2 * multiplier;

        int positonMod = positionNum % 7;
        switch (positonMod)
        {
            case 0:
                positionFix.x = 0;
                break;
            case 1:
                positionFix.x = -1;
                break;
            case 2:
                positionFix.x = 1;
                break;
            case 3:
                positionFix.x = -2;
                break;
            case 4:
                positionFix.x = 2;
                break;
            case 5:
                positionFix.x = -3;
                break;
            case 6:
                positionFix.x = 3;
                break;

        }
    }

    public void Follow()
    {

        followerr.DOMove(followedPlayer.transform.position + positionFix, .5f);
        followerr.DOLookAt(followedPlayer.transform.position, .5f);

    }
    public void SelfDestruct()
    {
        UnityEngine.Object.Destroy(followerr.gameObject);
        followerr.DOKill();
    }

    public int GetNumber()
    {
        return positionNum;
    }

}
