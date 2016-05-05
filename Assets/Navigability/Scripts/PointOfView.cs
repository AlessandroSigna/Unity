using UnityEngine;
using System.Collections;

public class PointOfView : MonoBehaviour {


    public Material skybox = null;
    public GameObject[] visiblePOI;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //Tutti i PoI visibili diventano inattivi
    public void LeavePOV()
    {
        foreach (GameObject go in visiblePOI)
        {
            go.SetActive(false);
        }
    }

    //Tutti i PoI visibili diventano attivi


    //renderizza lo skybox e rende visibili i PoI relativi alla sua vista
    public void BecamePOV()
    {

        if (skybox != null)
        {
            RenderSettings.skybox = skybox;
        }
        foreach (GameObject go in visiblePOI)
        {
            go.SetActive(true);
        }
    }
}
