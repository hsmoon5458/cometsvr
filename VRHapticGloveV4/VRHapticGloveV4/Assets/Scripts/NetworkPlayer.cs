using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;


public class NetworkPlayer : MonoBehaviour
{
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;
    private PhotonView photonView;

    private Transform headRig;
    private Transform leftHandrig;
    private Transform rightHandrig;

    void Start()
    {
        photonView = GetComponent<PhotonView>();
        OVRCameraRig rig = FindObjectOfType<OVRCameraRig>();

        headRig = rig.transform.Find("TrackingSpace/CenterEyeAnchor");
        leftHandrig = rig.transform.Find("TrackingSpace/LeftHandAnchor/OVRCustomHandPrefab_L");
        rightHandrig = rig.transform.Find("TrackingSpace/RightHandAnchor/OVRCustomHandPrefab_R");

    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            rightHand.gameObject.SetActive(false);
            leftHand.gameObject.SetActive(false);
            head.gameObject.SetActive(false);

            MapPosition(head, headRig);
            MapPosition(leftHand, leftHandrig);
            MapPosition(rightHand, rightHandrig);
        }
        
    }

    void MapPosition(Transform target, Transform rigTransform)
    {
        target.position = rigTransform.position;
        target.rotation = rigTransform.rotation;
    }
}
