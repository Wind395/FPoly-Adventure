using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject stairUI;
    [SerializeField] private GameObject lockDoor;

    [SerializeField] private Button[] buttons;

    // Start is called before the first frame update
    void Start()
    {
        // Khi quay về scene cũ thì Load lại vị trí được lưu trước đó
        if (SceneManager.GetActiveScene().name == "Front of P") {
            transform.position = GameManager.lastPositionSceneFrontofP;
        }
        if (SceneManager.GetActiveScene().name == "Floor 1") {
            transform.position = GameManager.lastPositionSceneFloor1;
        }
        if (SceneManager.GetActiveScene().name == "Floor 2") {
            transform.position = GameManager.lastPositionSceneFloor2;
        }
        if (SceneManager.GetActiveScene().name == "Floor 3") {
            transform.position = GameManager.lastPositionSceneFloor3;
        }
        if (SceneManager.GetActiveScene().name == "Floor 4") {
            transform.position = GameManager.lastPositionSceneFloor4;
        }
        if (SceneManager.GetActiveScene().name == "P203") {
            transform.position = GameManager.lastPositionSceneP203;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            stairUI.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.Return) && cFloor1 == true){
            GameManager.lastPositionSceneFrontofP = transform.position;
            GameManager.instance.ChangeScene("Floor 1");
        }
        if(Input.GetKeyDown(KeyCode.Return) && cFrontOfP == true){
            GameManager.lastPositionSceneFloor1 = transform.position;
            GameManager.instance.ChangeScene("Front of P");
        }
        if(Input.GetKeyDown(KeyCode.Return) && cP203 == true){
            GameManager.lastPositionSceneFloor2 = transform.position;
            GameManager.instance.ChangeScene("P203");
        }
        if(Input.GetKeyDown(KeyCode.Return) && cP202 == true){
            GameManager.lastPositionSceneFloor2 = transform.position;
            GameManager.instance.ChangeScene("P202");
        }
        if(Input.GetKeyDown(KeyCode.Return) && cP301 == true){
            GameManager.lastPositionSceneFloor3 = transform.position;
            GameManager.instance.ChangeScene("P301");
        }
        if(Input.GetKeyDown(KeyCode.Return) && cP404 == true){
            GameManager.lastPositionSceneFloor4 = transform.position;
            GameManager.instance.ChangeScene("P404");
        }
        if(Input.GetKeyDown(KeyCode.Return) && cFloor2 == true){
            GameManager.lastPositionSceneP203 = transform.position;
            GameManager.instance.ChangeScene("Floor 2");
        }
        if(Input.GetKeyDown(KeyCode.Return) && cFloor3 == true){
            GameManager.instance.ChangeScene("Floor 3");
        }
        if(Input.GetKeyDown(KeyCode.Return) && cFloor4 == true){
            GameManager.instance.ChangeScene("Floor 4");
        }
        if(Input.GetKeyDown(KeyCode.Return) && cStair == true){
            stairUI.SetActive(true);
        }
    }

    private bool cFloor1 = false;
    private bool cFloor2 = false;
    private bool cFloor3 = false;
    private bool cFloor4 = false;
    private bool cFrontOfP = false;
    private bool cP203 = false;
    private bool cP202 = false;
    private bool cP301 = false;
    private bool cP404 = false;
    private bool cStair = false;
    private void OnTriggerEnter2D(Collider2D other) {

        // Chuyển Scene và Save vị trí các Scene trước đó trước khi chuyển Scene

        if(other.gameObject.CompareTag("deochovao")){
            lockDoor.SetActive(true);
        }
        if (other.gameObject.CompareTag("InSideP")){
            cFloor1 = true;
        }
        if (other.gameObject.CompareTag("OutSideP")){
            cFrontOfP = true;            
        }
        if (other.gameObject.CompareTag("P203")) {
            cP203 = true;            
        }
        if (other.gameObject.CompareTag("P202")) {
            cP202 = true;            
        }
        if (other.gameObject.CompareTag("P301")) {
            cP301 = true;
        }
        if (other.gameObject.CompareTag("P404")) {
            cP404 = true;
        }
        if (other.gameObject.CompareTag("Lobby")) {
            cFloor2 = true;
        }
        if (other.gameObject.CompareTag("Lobby3")) {
            cFloor3 = true;
        }
        if (other.gameObject.CompareTag("Lobby4")) {
            cFloor4 = true;
        }
        if (other.gameObject.CompareTag("Stair")) 
        {
            cStair = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {

        // Chuyển Scene và Save vị trí các Scene trước đó trước khi chuyển Scene

        if (other.gameObject.CompareTag("InSideP")){
            cFloor1 = false;
        }
        if (other.gameObject.CompareTag("OutSideP")){
            cFrontOfP = false;            
        }
        if (other.gameObject.CompareTag("P203")) {
            cP203 = false;            
        }
        if (other.gameObject.CompareTag("P202")) {
            cP202 = false;            
        }
        if (other.gameObject.CompareTag("P301")) {
            cP301 = false;
        }
        if (other.gameObject.CompareTag("P404")) {
            cP404 = false;
        }
        if (other.gameObject.CompareTag("Lobby")) {
            cFloor2 = false;
        }
        if (other.gameObject.CompareTag("Lobby3")) {
            cFloor3 = false;
        }
        if (other.gameObject.CompareTag("Lobby4")) {
            cFloor4 = false;
        }
        if (other.gameObject.CompareTag("Stair")) 
        {
            cStair = false;
        }
        if(other.gameObject.CompareTag("deochovao")){
            lockDoor.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
    }

    public void OnButtonClick(int index) {
        // Save và chuyển Scene theo các tầng
        if (index == 1) {
            GameManager.lastPositionSceneFloor1 = transform.position;
            GameManager.instance.ChangeScene("Floor 1");
        }
        if (index == 2) {
            GameManager.lastPositionSceneFloor2 = transform.position;
            GameManager.instance.ChangeScene("Floor 2");
        }
        if (index == 3) {
            GameManager.lastPositionSceneFloor3 = transform.position;
            GameManager.instance.ChangeScene("Floor 3");
        }
        if (index == 4) {
            GameManager.lastPositionSceneFloor4 = transform.position;
            GameManager.instance.ChangeScene("Floor 4");
        }
    }

    // Chắc là rác do TriggerStay như ...
    private bool IsMoving() {
        return Input.GetAxis("Horizontal") == 0 || Input.GetAxis("Vertical") == 0;
}
}
