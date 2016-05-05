using UnityEngine;
using System.Collections;

public class POVManager : MonoBehaviour {

    //public GameObject currentPin = null;
    public PointOfView currentPOV = null;

	// Use this for initialization
	void Start () {
        //if (currentPin != null) {
        //    currentPin.SetActive(false);
        //}
        if (currentPOV != null)
        {
            currentPOV.BecamePOV();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    ////Activate the old pin and deactivate the new one
    //public void updatePin(GameObject Pin) {
    //    currentPin.SetActive(true);
    //    Pin.GetComponent<ChangeSkybox>().OnGazeExit();
    //    Pin.SetActive(false);
    //    currentPin = Pin;
    //}

    //Activate the old pin and deactivate the new one
    public void updatePoV(PointOfView newPoV)
    {
        newPoV.BecamePOV();
        currentPOV.LeavePOV();
        currentPOV = newPoV;
    }
}
