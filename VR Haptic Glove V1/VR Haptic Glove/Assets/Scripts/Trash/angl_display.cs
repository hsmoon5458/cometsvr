using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class angl_display : MonoBehaviour
{
    public Transform tf;
    public Text angl_value;
    void Update()
    {
        angl_value.text = tf.transform.eulerAngles.y.ToString("0");
    }
}
