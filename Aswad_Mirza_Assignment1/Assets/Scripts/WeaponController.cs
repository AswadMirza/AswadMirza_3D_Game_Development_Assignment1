using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    // Gun Objects
    public GameObject pistol;
    public GameObject smg;

    // transforms for the hip and hand
    public Transform handBone;
    public Transform hipBone;

    //vector 3  for hand positions
    public Vector3 handPositionOffset;
    public Vector3 handRotationOffset;

    // vector 3 for hip position
    public Vector3 hipPositionOffset;
    public Vector3 hipRotationOffset;

    GameObject selectedWeapon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    void findSelectedWeapon() {
        string gunName = pistol.name;
        string smgName = smg.name;

        // the weapon in the hand is the selected weapon
        foreach (Transform child in handBone) {
            if (child.name.Equals(gunName))
            {

                selectedWeapon = pistol;
            }
            else if(child.name.Equals(smgName)) {
                selectedWeapon = smg;
            }
        } 
    }

    public GameObject getSelectedWeapon() {
        findSelectedWeapon();
        return selectedWeapon;
    }


}
