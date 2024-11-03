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
    
    public Image fadeImage; // Image để làm hiệu ứng fade
    public float fadeDuration = 1f; // Thời gian hiệu ứng fade

    public GameObject enter;
    public GameObject F;
    public GameObject exit;
    public GameObject E;

    // Start is called before the first frame update
    void Start()
    {
        // Bắt đầu với hiệu ứng fade in khi vào scene
        StartCoroutine(FadeIn());
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
            FadeToScene("Floor 1");
        }
        if(Input.GetKeyDown(KeyCode.Return) && cFrontOfP == true){
            GameManager.lastPositionSceneFloor1 = transform.position;
            FadeToScene("Front of P");
        }
        if(Input.GetKeyDown(KeyCode.Return) && cP203 == true){
            GameManager.lastPositionSceneFloor2 = transform.position;
            FadeToScene("P203");
        }
        if(Input.GetKeyDown(KeyCode.Return) && cP202 == true){
            GameManager.lastPositionSceneFloor2 = transform.position;
            FadeToScene("P202");
        }
        if(Input.GetKeyDown(KeyCode.Return) && cP301 == true){
            GameManager.lastPositionSceneFloor3 = transform.position;
            FadeToScene("P301");
        }
        if(Input.GetKeyDown(KeyCode.Return) && cP404 == true){
            GameManager.lastPositionSceneFloor4 = transform.position;
            FadeToScene("P404");
        }
        if(Input.GetKeyDown(KeyCode.Return) && cFloor2 == true){
            GameManager.lastPositionSceneP203 = transform.position;
            FadeToScene("Floor 2");
        }
        if(Input.GetKeyDown(KeyCode.Return) && cFloor3 == true){
            FadeToScene("Floor 3");
        }
        if(Input.GetKeyDown(KeyCode.Return) && cFloor4 == true && GameManager.instance.paper == 4){
            FadeToScene("Floor 1");
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
    private bool girl = false;
    private void OnTriggerEnter2D(Collider2D other) {

        // Chuyển Scene và Save vị trí các Scene trước đó trước khi chuyển Scene

        if(other.gameObject.CompareTag("deochovao")){
            lockDoor.SetActive(true);
        }
        if (other.gameObject.CompareTag("InSideP")){
            enter.SetActive(true);
            cFloor1 = true;
        }
        if (other.gameObject.CompareTag("OutSideP")){
            enter.SetActive(true);
            cFrontOfP = true;            
        }
        if (other.gameObject.CompareTag("P203")) {
            enter.SetActive(true);
            cP203 = true;            
        }
        if (other.gameObject.CompareTag("P202")) {
            enter.SetActive(true);
            cP202 = true;            
        }
        if (other.gameObject.CompareTag("P301")) {
            enter.SetActive(true);
            cP301 = true;
        }
        if (other.gameObject.CompareTag("P404")) {
            enter.SetActive(true);
            cP404 = true;
        }
        if (other.gameObject.CompareTag("Lobby")) {
            enter.SetActive(true);
            cFloor2 = true;
        }
        if (other.gameObject.CompareTag("Lobby3")) {
            enter.SetActive(true);
            cFloor3 = true;
        }
        if (other.gameObject.CompareTag("Lobby4")) {
            enter.SetActive(true);
            cFloor4 = true;
        }
        if (other.gameObject.CompareTag("Stair")) 
        {
            enter.SetActive(true);
            cStair = true;
        }
        if(other.gameObject.CompareTag("Golden Bee"))
        {
            F.SetActive(true);
        }
        if (other.gameObject.CompareTag("BeePoly"))
        {
            E.SetActive(true);
        }
        if (other.gameObject.CompareTag("Paper"))
        {
            F.SetActive(true);
        }
        if (other.gameObject.CompareTag("Girl"))
        {
            E.SetActive(true);
            girl = true;
        }
        if (other.gameObject.CompareTag("Information Active"))
        {
            F.SetActive(true);
            
        }
        if (other.gameObject.CompareTag("Boy"))
        {
            E.SetActive(true);

        }
        if (other.gameObject.CompareTag("Door"))
        {
            E.SetActive(true);

        }


    }
    private void OnTriggerExit2D(Collider2D other) {

        // Chuyển Scene và Save vị trí các Scene trước đó trước khi chuyển Scene
        if(other.gameObject.CompareTag("Golden Bee"))
        {
            F.SetActive(false);
        }
        if (other.gameObject.CompareTag("BeePoly"))
        {
            E.SetActive(false);
        }
        if (other.gameObject.CompareTag("Paper"))
        {
            F.SetActive(false);
        }
        if (other.gameObject.CompareTag("Girl"))
        {
            E.SetActive(false);
            girl=false;
        }
        if (other.gameObject.CompareTag("Information Active"))
        {
            F.SetActive(false);
           
        }
        if (other.gameObject.CompareTag("Boy"))
        {
            E.SetActive(false);

        }
        if (other.gameObject.CompareTag("Door"))
        {
            E.SetActive(false);

        }


        if (other.gameObject.CompareTag("InSideP")){
            enter.SetActive(false);
            cFloor1 = false;
        }
        if (other.gameObject.CompareTag("OutSideP")){
            enter.SetActive(false);
            cFrontOfP = false;            
        }
        if (other.gameObject.CompareTag("P203")) {
            enter.SetActive(false);
            cP203 = false;            
        }
        if (other.gameObject.CompareTag("P202")) {
            enter.SetActive(false);
            cP202 = false;            
        }
        if (other.gameObject.CompareTag("P301")) {
            enter.SetActive(false);
            cP301 = false;
        }
        if (other.gameObject.CompareTag("P404")) {
            enter.SetActive(false);
            cP404 = false;
        }
        if (other.gameObject.CompareTag("Lobby")) {
            enter.SetActive(false);
            cFloor2 = false;
        }
        if (other.gameObject.CompareTag("Lobby3")) {
            enter.SetActive(false);
            cFloor3 = false;
        }
        if (other.gameObject.CompareTag("Lobby4")) {
            enter.SetActive(false);
            cFloor4 = false;
        }
        if (other.gameObject.CompareTag("Stair")) 
        {
            enter.SetActive(false);
            cStair = false;
        }
        if(other.gameObject.CompareTag("deochovao")){
            lockDoor.SetActive(false);
        }
    }

    public void OnButtonClick(int index) {
        // Save và chuyển Scene theo các tầng
        if (index == 1) {
            GameManager.lastPositionSceneFloor1 = transform.position;
            FadeToScene("Floor 1");
        }
        if (index == 2) {
            GameManager.lastPositionSceneFloor2 = transform.position;
            FadeToScene("Floor 2");
        }
        if (index == 3) {
            GameManager.lastPositionSceneFloor3 = transform.position;
            FadeToScene("Floor 3");
        }
        if (index == 4) {
            GameManager.lastPositionSceneFloor4 = transform.position;
            FadeToScene("Floor 4");
        }
    }


    // Hàm để chuyển scene với hiệu ứng fade out
    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeOut(sceneName));
    }

    // Coroutine để thực hiện fade in
    private IEnumerator FadeIn()
    {
        float t = fadeDuration;
        while (t > 0f)
        {
            t -= Time.deltaTime;
            Color color = fadeImage.color;
            color.a = t / fadeDuration;
            fadeImage.color = color;
            yield return null;
        }
    }

    // Coroutine để thực hiện fade out và chuyển scene
    private IEnumerator FadeOut(string sceneName)
    {
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            Color color = fadeImage.color;
            color.a = t / fadeDuration;
            fadeImage.color = color;
            yield return null;
        }

        // Chuyển scene sau khi fade out hoàn tất
        GameManager.instance.ChangeScene(sceneName);
    }
}
