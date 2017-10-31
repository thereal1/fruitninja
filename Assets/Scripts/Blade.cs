using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour {

    public float minCuttingVelocity = 0.001f;
    public GameObject bladeTrialPrefab;

    private bool isCutting = false;
    private Vector2 previousPosition;
    private Rigidbody2D rb;
    private Camera cam;
    private GameObject currentBladeTrail;
    private CircleCollider2D circleCollider;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        cam = Camera.main;
    }

    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            StartCutting();
        } else if (Input.GetMouseButtonUp(0)) {
            StopCutting();
        }

        if (isCutting)
        {
            UpdateCut();
        }
	}

    private void StartCutting()
    {
        isCutting = true;
        currentBladeTrail = Instantiate(bladeTrialPrefab, transform);
        previousPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        circleCollider.enabled = false;
    }

    private void StopCutting()
    {
        isCutting = false;
        currentBladeTrail.transform.SetParent(null);
        Destroy(currentBladeTrail, 2f);
        circleCollider.enabled = false;
    }

    private void UpdateCut()
    {
        Vector2 newPostion = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newPostion;

        float velocity = (newPostion - previousPosition).magnitude * Time.deltaTime;
        if (velocity > minCuttingVelocity)
        {
            circleCollider.enabled = true;
        } else
        {
            circleCollider.enabled = false;
        }

        previousPosition = newPostion;
    }
}
