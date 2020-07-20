using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script allows us to set the player under the "PlayerTracker" empty object
//Doing so will make sure that any FollowAIs aim to chase/follow this object
public class PlayerTracker : MonoBehaviour {

    #region Singleton

    public static PlayerTracker instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;

}
