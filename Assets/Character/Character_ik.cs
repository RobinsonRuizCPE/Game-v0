using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_ik : MonoBehaviour
{
    public bool IsGrounded;
    public bool IsIkActivated;
    private TerrainCollider _TerrainCollider;
    private TerrainData _TerrainData;

    private Transform LeftLeg;
    private Transform RightLeg;
    private Transform Base;

    // Start is called before the first frame update
    void Start()
    {
        LeftLeg = gameObject.transform.Find("Armature/root/ik-leg.l");
        RightLeg = gameObject.transform.Find("Armature/root/ik-leg.r");
        Base = gameObject.transform.Find("Armature/root/base");
        _TerrainData = GameObject.Find("Terrain").GetComponent<TerrainData>();
        _TerrainCollider = GameObject.Find("Terrain").GetComponent<TerrainCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsGrounded || !IsIkActivated) {
            return;
        }
        RaycastHit hit;
        Ray left_ray = new Ray(LeftLeg.position, new Vector3(0f, -10f, 0f));
        _TerrainCollider.Raycast(left_ray, out hit, 10);
        Base.transform.Translate(new Vector3(0, 0, -0.005f),Space.Self);
        /*if (hit.collider != null)
        {
            LeftLeg.position = hit.point + new Vector3(0, 0.1f, 0);
        }*/
        
        
            //_TerrainData.GetInterpolatedNormal()
    }
}
