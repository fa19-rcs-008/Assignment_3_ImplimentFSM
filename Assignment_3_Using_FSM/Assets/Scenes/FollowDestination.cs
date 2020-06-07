﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowDestination : MonoBehaviour
{
    private NavMeshAgent agent = null;
    public Transform destination = null;

    //is player walking ?
    public bool walk = false;

    // is player stop walking?
    public bool stand = false;

    // is Eat Tablet ?
    public bool eatTablet = false;

    // is superPowerTimeOut?
    public bool superPowerTimeout = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Capsule")
        {
            Debug.Log("Capsule");
            other.gameObject.SetActive(false);
            eatTablet = true;
            StartCoroutine(SuperTimeout());
        }
    }

    IEnumerator SuperTimeout()
    {
        yield return new WaitForSeconds(8f);
        superPowerTimeout = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(destination.position);
    }
}
