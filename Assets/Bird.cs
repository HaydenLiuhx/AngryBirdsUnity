using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    bool OnClicked = false;

    public Transform CenterPos;
    public float MaxDistance = 2f;

    SpringJoint2D spj;

    public float ReleaseTime = 0.15f;

    Rigidbody2D rg;

    public LineRenderer FrontLine;
    public LineRenderer BackLine;

    public Transform FrontBond;
    public Transform BackBond;
    // Start is called before the first frame update
    void Start()
    {
        spj = GetComponent<SpringJoint2D>();
        rg = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OnClicked)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);

            FrontLine.SetPosition(0, FrontBond.position);
            FrontLine.SetPosition(1, transform.position);
            BackLine.SetPosition(0, BackBond.position);
            BackLine.SetPosition(1, transform.position);

            if (Vector3.Distance(transform.position,CenterPos.position) > MaxDistance)
            {
                Vector3 direction = (transform.position - CenterPos.position).normalized * MaxDistance;
                transform.position = CenterPos.position + direction;
                FrontLine.SetPosition(0, FrontBond.position);
                FrontLine.SetPosition(1, transform.position);
                BackLine.SetPosition(0, BackBond.position);
                BackLine.SetPosition(1, transform.position);
            }
        }
    }
    private void OnMouseDown()
    {
        OnClicked = true;
        rg.isKinematic = true;
    }
     
    private void OnMouseUp()
    {
        OnClicked = false;
        rg.isKinematic = false;
        StartCoroutine(Release());
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(ReleaseTime);
        spj.enabled = false;
        FrontLine.enabled = false;
        BackLine.enabled = false;
    }
}
