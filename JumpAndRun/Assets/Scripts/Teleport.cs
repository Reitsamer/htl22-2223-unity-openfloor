using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private Material material;

    [SerializeField]
    private float speed = 1f;

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
                if (Input.GetKeyDown(KeyCode.T))
                {
                    state = State.FadingOut;
                }
                break;
            case State.FadingIn:
            {
                // _Fade = 1 -> state = State.FadedIn
                float fade = material.GetFloat("_Fade");
                fade += Time.deltaTime * speed;
                if (fade >= 1)
                {
                    fade = 1;
                    state = State.FadedIn;
                }

                material.SetFloat("_Fade", fade);
                break;
            }
            case State.FadingOut:
            {
                float fade = material.GetFloat("_Fade");
                fade -= Time.deltaTime * speed;
                if (fade <= 0)
                {
                    fade = 0;
                    state = State.FadedOut;
                }

                material.SetFloat("_Fade", fade);
                break;
            }
            case State.FadedOut:
                if (Input.GetKeyDown(KeyCode.T))
                {
                    state = State.FadingIn;
                }
                break;
            default:
                break;
        }   
    }
}
