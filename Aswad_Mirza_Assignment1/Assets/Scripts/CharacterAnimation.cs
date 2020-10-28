using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterAnimation : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {

        // if one is held down, set hip hop to true, else set it to false
        if (Input.GetKey(KeyCode.Alpha1))
        {
            anim.SetBool("HipHop", true);
        }
        else {
            anim.SetBool("HipHop", false);
        }

        // if 2 is held down

        if (Input.GetKey(KeyCode.Alpha2))
        {
            anim.SetBool("House", true);
        }
        else
        {
            anim.SetBool("House", false);
        }

        // if 3 is held down

        if (Input.GetKey(KeyCode.Alpha3))
        {
            anim.SetBool("Robot", true);
        }
        else
        {
            anim.SetBool("Robot", false);
        }

        // if 4 is held down

        if (Input.GetKey(KeyCode.Alpha4))
        {
            anim.SetBool("Salsa", true);
        }
        else
        {
            anim.SetBool("Salsa", false);
        }
        // if 5 is held down
        if (Input.GetKey(KeyCode.Alpha5))
        {
            anim.SetBool("Samba", true);
        }
        else
        {
            anim.SetBool("Samba", false);
        }
        // if 6 is held down
        if (Input.GetKey(KeyCode.Alpha6))
        {
            anim.SetBool("Swing", true);
        }
        else
        {
            anim.SetBool("Swing", false);
        }

    }
}
