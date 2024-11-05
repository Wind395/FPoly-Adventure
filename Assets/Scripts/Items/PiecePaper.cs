using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecePaper : item
{
    public override void Interact()
    {
        if (pickUp == true && gameObject.tag == "Paper" && Input.GetKeyDown(KeyCode.F))
        {
            GameManager.instance.CollectPapers();
            Collect();
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
