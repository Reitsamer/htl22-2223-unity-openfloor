using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private Material material;

    private enum State
    {
        FadedIn,
        FadingIn,
        FadedOut,
        FadingOut
    }

    private State state;
    
    // Start is called before the first frame update
    void Start()
    {
        state = State.FadedIn;
        
        material = GetComponent<SpriteRenderer>().material;
        material.SetFloat("_Fade", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.FadedIn:
                // Space pressed -> state = State.FadingOut
                break;
            case State.FadingIn:
                // _Fade = 1 -> state = State.FadedIn
                break;
            case State.FadingOut:
                break;
            case State.FadedOut:
                break;
            default:
                break;
        }   
    }
}
