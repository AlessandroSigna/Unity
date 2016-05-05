using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Collider))]
public class PointOfInterest : MonoBehaviour, ICardboardGazeResponder
{
    public POVManager pinManager = null;
    private bool shrinking = false;
    private bool expanding = false;
    private float originalSize;
    private float targetSize;
    private float resizeSpeed;

    public PointOfView targetPOV = null;

    void Start()
    {
        Debug.Log("Start", gameObject);
        originalSize = transform.localScale.x;
        targetSize = originalSize * 1.2f;
        resizeSpeed = originalSize * 2f;
    }

    

    void Shrink()
    {
        expanding = false;
        shrinking = true;
    }

    void Expand()
    {
        shrinking = false;
        expanding = true;
    }

    void Update()
    {
        if (shrinking)
        {
            transform.localScale -= Vector3.one * Time.deltaTime * resizeSpeed;
            if (transform.localScale.x < originalSize)
                shrinking = false;
        }
        else if (expanding)
        {
            transform.localScale += Vector3.one * Time.deltaTime * resizeSpeed;
            if (transform.localScale.x > targetSize)
                expanding = false;
        }
    }



    void LateUpdate()
    {
        Cardboard.SDK.UpdateState();
        if (Cardboard.SDK.BackButtonPressed)
        {
            Application.Quit();
        }
    }


    #region ICardboardGazeResponder implementation

    /// Called when the user is looking on a GameObject with this script,
    /// as long as it is set to an appropriate layer (see CardboardGaze).
    public void OnGazeEnter()
    {
        Debug.Log("Entrato", gameObject);
        Expand();
    }

    /// Called when the user stops looking on the GameObject, after OnGazeEnter
    /// was already called.
    public void OnGazeExit()
    {
        Debug.Log("Uscito", gameObject);
        Shrink();
    }

    // Called when the Cardboard trigger is used, between OnGazeEnter
    /// and OnGazeExit.
    public void OnGazeTrigger()
    {
        Debug.Log("Cliccato", gameObject);
        pinManager.updatePoV(targetPOV);
    }

    #endregion
}
