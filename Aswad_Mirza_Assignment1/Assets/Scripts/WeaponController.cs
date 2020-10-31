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
    GameObject holsteredWeapon;

    MouseAim mouseAim;
    // Start is called before the first frame update
    void Start()
    {
        mouseAim = gameObject.GetComponent<MouseAim>();
    }

    // Update is called once per frame
    void Update()
    {

        if (getSelectedWeapon() != null) {
            mouseAim.weapon = selectedWeapon.transform;
        }

        //mouse wheel scrolling down
        if (Input.GetAxis("Mouse ScrollWheel") < 0f) {
            swapWeapons();
            Debug.Log("weapons are swapped");
        }
    }
    //problem need to set the gameobjects to the weapons already inside of the player, and not the ones in the prefab
    void swapWeapons() {
        GameObject newPistol;
        GameObject newSMG;
        findSelectedWeapon();
        findHolsteredWeapon();
        if (IsBothWeaponsOnPlayer()) {
            if (selectedWeapon.name.Equals(pistol.name))
            {
                Destroy(selectedWeapon);
                Destroy(holsteredWeapon);

                newPistol = Instantiate(pistol, hipBone.position, hipBone.rotation);
                newPistol.name = pistol.name;
                newPistol.transform.SetParent(hipBone);
                newPistol.transform.localPosition = hipPositionOffset;
                newPistol.transform.localEulerAngles = hipRotationOffset;


                newSMG = Instantiate(smg, handBone.position, handBone.rotation);
                newSMG.name = smg.name;
                newSMG.transform.SetParent(handBone);
                newSMG.transform.localPosition = handPositionOffset;
                newSMG.transform.localEulerAngles = handRotationOffset;

                selectedWeapon = newSMG;
                holsteredWeapon = newPistol;

                mouseAim.weapon = selectedWeapon.transform;
                Debug.Log("Switched from pistol to smg");
            }

            else if (selectedWeapon.name.Equals(smg.name)) {

                Destroy(selectedWeapon);
                Destroy(holsteredWeapon);

                newPistol = Instantiate(pistol, handBone.position, handBone.rotation);
                newPistol.name = pistol.name;
                newPistol.transform.SetParent(handBone);
                newPistol.transform.localPosition = handPositionOffset;
                newPistol.transform.localEulerAngles = handRotationOffset;


                newSMG = Instantiate(smg, hipBone.position, hipBone.rotation);
                newSMG.name = smg.name;
                newSMG.transform.SetParent(hipBone);
                newSMG.transform.localPosition = hipPositionOffset;
                newSMG.transform.localEulerAngles = hipRotationOffset;


                selectedWeapon = newPistol;
                holsteredWeapon = newSMG;

                mouseAim.weapon = selectedWeapon.transform;
                Debug.Log("Switched from smg to pistol");
            }
        }
    }

    bool IsBothWeaponsOnPlayer() {
        bool bothWeapons = false;
        bool isPistol = false;
        bool isSMG = false;

        foreach (Transform child in handBone) {
            if (child.name.Equals(pistol.name))
            {
                isPistol = true;
            }
            else if(child.name.Equals(smg.name)){
                isSMG = true;
            }
        
        }

        foreach (Transform child in hipBone) {
            if (child.name.Equals(pistol.name))
            {
                isPistol = true;
            }
            else if (child.name.Equals(smg.name))
            {
                isSMG = true;
            }
        }

        if (isPistol && isSMG)
        {
            bothWeapons = true;
        }
        else {
            bothWeapons = false;
        }

        return bothWeapons;
    }

    void findSelectedWeapon() {
        string gunName = pistol.name;
        string smgName = smg.name;

        // the weapon in the hand is the selected weapon
        foreach (Transform child in handBone) {
            if (child.name.Equals(gunName) || child.name.Equals(smgName))
            {

                selectedWeapon = child.gameObject;
            }
            /*
            else if(child.name.Equals(smgName)) {
                selectedWeapon = smg;
            }
            */
        }
    }

    void findHolsteredWeapon() {
        string gunName = pistol.name;
        string smgName = smg.name;

        // the weapon in the hip is the holstered weapon
        foreach (Transform child in hipBone)
        {
            if (child.name.Equals(gunName) || child.name.Equals(smgName))
            {

                holsteredWeapon = child.gameObject;
            }
            /*
            else if(child.name.Equals(smgName)) {
                selectedWeapon = smg;
            }
            */
        }
    }

    public GameObject getSelectedWeapon() {
        findSelectedWeapon();
        return selectedWeapon;
    }

    public GameObject getHolsteredWeapon() {
        findHolsteredWeapon();
        return holsteredWeapon;
    }


}
