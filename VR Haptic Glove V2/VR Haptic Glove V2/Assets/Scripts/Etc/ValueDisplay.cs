using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueDisplay : MonoBehaviour
{
    public Text left_m1, left_m2, left_m3, left_m4, left_m5, left_m6, left_m7, left_m8, left_m9;
    //public Text right_m1, right_m2, right_m3, right_m4, right_m5, right_m6, right_m7, right_m8, right_m9;
    public Text left_b1, left_b2, left_b3, left_b4, left_b5, left_b6, left_b7, left_b8, left_b9;
    //public Text right_b1, right_b2, right_b3, right_b4, right_b5, right_b6, right_b7, right_b8, right_b9;
    public Text l1, l2, l3, l4, l5, l6, l7, l8, l9, r1, r2, r3, r4, r5, r6, r7, r8, r9;

    void Update()
    {
        l1.text = Mathf.RoundToInt(LeftHandTracking.left_angl[0]).ToString();
        l2.text = Mathf.RoundToInt(LeftHandTracking.left_angl[1]).ToString();
        l3.text = Mathf.RoundToInt(LeftHandTracking.left_angl[2]).ToString();
        l4.text = Mathf.RoundToInt(LeftHandTracking.left_angl[3]).ToString();
        l5.text = Mathf.RoundToInt(LeftHandTracking.left_angl[4]).ToString();
        l6.text = Mathf.RoundToInt(LeftHandTracking.left_angl[5]).ToString();
        l7.text = Mathf.RoundToInt(LeftHandTracking.left_angl[6]).ToString();
        l8.text = Mathf.RoundToInt(LeftHandTracking.left_angl[7]).ToString();
        l9.text = Mathf.RoundToInt(LeftHandTracking.left_angl[8]).ToString();

        r1.text = Mathf.RoundToInt(RightHandTracking.right_angl[0]).ToString();
        r2.text = Mathf.RoundToInt(RightHandTracking.right_angl[1]).ToString();
        r3.text = Mathf.RoundToInt(RightHandTracking.right_angl[2]).ToString();
        r4.text = Mathf.RoundToInt(RightHandTracking.right_angl[3]).ToString();
        r5.text = Mathf.RoundToInt(RightHandTracking.right_angl[4]).ToString();
        r6.text = Mathf.RoundToInt(RightHandTracking.right_angl[5]).ToString();
        r7.text = Mathf.RoundToInt(RightHandTracking.right_angl[6]).ToString();
        r8.text = Mathf.RoundToInt(RightHandTracking.right_angl[7]).ToString();
        r9.text = Mathf.RoundToInt(RightHandTracking.right_angl[8]).ToString();

        left_m1.text = LeftHandTracking.m_left[0].ToString();
        left_m2.text = LeftHandTracking.m_left[1].ToString();
        left_m3.text = LeftHandTracking.m_left[2].ToString();
        left_m4.text = LeftHandTracking.m_left[3].ToString();
        left_m5.text = LeftHandTracking.m_left[4].ToString();
        left_m6.text = LeftHandTracking.m_left[5].ToString();
        left_m7.text = LeftHandTracking.m_left[6].ToString();
        left_m8.text = LeftHandTracking.m_left[7].ToString();
        left_m9.text = LeftHandTracking.m_left[8].ToString();

        left_b1.text = LeftHandTracking.b_left[0].ToString();
        left_b2.text = LeftHandTracking.b_left[1].ToString();
        left_b3.text = LeftHandTracking.b_left[2].ToString();
        left_b4.text = LeftHandTracking.b_left[3].ToString();
        left_b5.text = LeftHandTracking.b_left[4].ToString();
        left_b6.text = LeftHandTracking.b_left[5].ToString();
        left_b7.text = LeftHandTracking.b_left[6].ToString();
        left_b8.text = LeftHandTracking.b_left[7].ToString();
        left_b9.text = LeftHandTracking.b_left[8].ToString();

    }
}
