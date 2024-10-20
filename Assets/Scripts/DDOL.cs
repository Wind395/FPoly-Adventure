using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DDOL : MonoBehaviour
{
    public int _paper;
    public int _bee;
    public TMP_Text paperText;
    public TMP_Text beeText;
    
    // Start is called before the first frame update
    void Start()
    {
        _paper = GameManager.instance.paper;
        _bee = GameManager.instance.beeBadge;
    }

    // Update is called once per frame
    void Update()
    {
        _paper = GameManager.instance.paper;
        _bee = GameManager.instance.beeBadge;
        paperText.text = $"Mảnh giấy: {_paper}/4";
        beeText.text = $"Ong vàng: {_bee}";
    }
}
