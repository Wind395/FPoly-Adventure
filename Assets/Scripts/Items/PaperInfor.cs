using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperInfor : item
{
    public override void Interact()
    {
        if (pickUp == true && gameObject.tag == "Information Active" && Input.GetKeyDown(KeyCode.F))
        {
            paperInforFloor4.SetActive(true);
            GameManager.instance.canRun = false;
            GameManager.instance.hasRead = true;
        }
        if (pickUp == true && gameObject.tag == "Information" && Input.GetKeyDown(KeyCode.F))
        {
            otherPaperInfor.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (gameObject.tag == "Information Active")
            {
                paperInforFloor4.SetActive(false);
                GameManager.instance.canRun = true;
                Debug.Log(GameManager.instance.canRun);
            }
            if (gameObject.tag == "Information")
            {
                otherPaperInfor.SetActive(false);
            }
        }
    }

    private void Collect()
    {
        // Đặt trạng thái đã nhặt và lưu vào PlayerPrefs
        isCollected = true;
        PlayerPrefs.SetInt(_itemID, 1);
        PlayerPrefs.Save();

        // Ẩn vật phẩm sau khi nhặt
        gameObject.SetActive(false);
    }
}
