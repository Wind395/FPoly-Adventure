using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FileAuthManager : MonoBehaviour
{
    public TMP_InputField _userName;
    public TMP_InputField _password;
    public TMP_Text _statusText;
    private string filePath;
    private void Start() {
        filePath = Application.persistentDataPath + "/users.txt";   //C:\Users\<Tên người dùng>\AppData\LocalLow\<Tên công ty>\ <Tên game>\users.txt - vào đấy thì Win+R
    }
    public void Register(){ //hàm đăng ký
        string userName = _userName.text;
        string password = _password.text;
        if(string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password)){   //kiểm tra xem 2 trường userName và password có trống hay ko
            _statusText.text = "Please fill in all fields";
            return;
        }
        if(IsRegisted(userName)){
            _statusText.text = "User already exists";
            return;
        }
        string userInfo = userName + "," + password + Environment.NewLine;  //lưu tk,mk vào file.
        File.AppendAllText(filePath, userInfo);
        _statusText.text = "Sign in successfully!";
    }
    public void Login(){    //hàm đăng nhập
        string userName = _userName.text;
        string password = _password.text;
        if(IsValidUser(userName, password)){
            _statusText.text = "Login successfully!";
            GameManager.getUsername = _userName.text; 
            StartCoroutine(WaitAndLoadScene());
        }else{
            _statusText.text = "User name or password in incorect.";
        }
    }
    private IEnumerator WaitAndLoadScene()
    {
        yield return new WaitForSeconds(2); // Chờ 2 giây
        SceneManager.LoadScene("Menu"); // Chuyển sang scene mới (thay "TênSceneMới" bằng tên scene của bạn)
    }
    private bool IsRegisted(string userName){   //kiểm tra tài khoản tồn tại chưa
        if(!File.Exists(filePath)) return false;    //nếu ko tìm thấy file thì trả về false
        string[] users = File.ReadAllLines(filePath);
        foreach(string user in users){  //mấy cái này lười giải thích
            string[] userData = user.Split(',');
            if(userData[0] == userName) {
                return true;
            }
        }
        return false;
    }
    private bool IsValidUser(string userName, string password){ //kiểm tra xem tk, mk có trong file ko
        if(!File.Exists(filePath)) return false;
        string[] users = File.ReadAllLines(filePath);
        foreach(string user in users){
            string[] userData = user.Split(',');
            if(userData[0] == userName && userData[1] == password){
                return true;
            }
        }
        return false;
    }
}
