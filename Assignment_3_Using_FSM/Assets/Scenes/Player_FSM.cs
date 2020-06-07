using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_FSM : MonoBehaviour
{

    public enum Enemy_State { Idle, Chasing, SuperPower,GameOver }
    private Controller controller;
    [SerializeField]
    private Enemy_State currentState;


    public Enemy_State CurrentState
    {
        get { return currentState; }
        set
        {
            currentState = value;
            StopAllCoroutines();

            switch (currentState)
            {
                case Enemy_State.Idle:
                    Debug.Log("in swith");
                    StartCoroutine(state_idle(true));
                    break;
                case Enemy_State.Chasing:
                    StartCoroutine(state_chasing(true));
                    break;
                case Enemy_State.SuperPower:
                    StartCoroutine(state_SuperPower(true));
                    break;
                case Enemy_State.GameOver:
                    StartCoroutine(state_GameOver(true));
                    break;

            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("in start");
        controller = GetComponent<Controller>();
        CurrentState = Enemy_State.Idle;

    }


    IEnumerator state_idle(bool check)
    {
        
            Debug.Log("in while idle"+controller.walk);
            Debug.Log("in while idle stand"+controller.stand);
            if (controller.walk) {
            Debug.Log("you are chase state");
            // CurrentState = Enemy_State.Chasing;
        }
        
        yield return null;

        
    }

    IEnumerator state_chasing(bool check)
    {
        while (check)
        {
            Debug.Log("in while");
            if (controller.stand)
            {
                Debug.Log("in stand");
                check = false;
                CurrentState = Enemy_State.Idle;
            }
            else if (controller.eatTablet) {
                Debug.Log("in super");
                check = false;
                CurrentState = Enemy_State.SuperPower;
            }
        }
        yield return null;

    }

    IEnumerator state_SuperPower(bool check)
    {
        while (check)
        {
            if (controller.superPowerTimeout)
            {
                check = false;
                CurrentState = Enemy_State.Chasing;
            }
        }
        yield return null;

    }

    IEnumerator state_GameOver(bool check)
    {
        while (check)
        {
            if (controller.walk)
            {
                check = false;
                CurrentState = Enemy_State.Chasing;
            }
        }
        yield return null;

    }

    // Update is called once per frame
    void Update()
    {
        state_idle(true);

    }
}
