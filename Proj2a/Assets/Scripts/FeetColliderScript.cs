﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetColliderScript : MonoBehaviour
{

    // Returns whether the obj is a floor
    bool isFloor(GameObject obj)
    {
        return obj.layer == LayerMask.NameToLayer("Floor");
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        GetComponentInParent<PlayerController>().feetContact = true;
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        GetComponentInParent<PlayerController>().feetContact = false;
    }
}
