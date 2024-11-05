using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightManager : MonoBehaviour
{
    // Danh sách các list được loại trừ để tắt
    [SerializeField] private GameObject[] exemptObjects;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TurnOnOffAllLights();
        }
    }

    // Phương thức sử dụng chức năng bật tắt đèn
    private void TurnOnOffAllLights()
    {
        // Tìm các Object có Component là Light2D
        Light2D[] lights = FindObjectsOfType<Light2D>();

        // Liệt kê các Object được loại trừ

        foreach (Light2D light in lights)
        {
            // Kiểm tra xem Object có trong danh sách loại trừ hay không bằng cách mỗi object có biến isExempt

            bool isExempt = false;
            foreach (GameObject exemptObject in exemptObjects)
            {
                //  Nếu Object có trong danh sách loại trừ thì biến isExempt sẽ được thiết lập thành True
                if (light.gameObject == exemptObject)
                {
                    // Khi Object đó có isExempt = true thì sẽ được loại trừ
                    isExempt = true;
                    break;
                }
            }
            // Nếu không thì ...
            if (!isExempt)
            {
                light.enabled = !light.enabled;
            }
        }
    }
}