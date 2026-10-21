using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour{
    public float speed=0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    private Rigidbody rb;
    private Vector2 movementVector;
    private int count;
    static Vector3 Vector2SwitchToVector3(Vector2 vec2){
        Vector3 vec3=new Vector3(vec2.x,0.0f,vec2.y);
        return vec3;
    }
    void Start(){
        rb=GetComponent<Rigidbody>();
        winTextObject.gameObject.SetActive(false);
        count=0;
        SetCountText();

    }
    void OnMove(InputValue movementValue){
        movementVector=movementValue.Get<Vector2>();
        Debug.Log("输入被触发了！");
    }
    void FixedUpdate(){
        Vector3 movement=Vector2SwitchToVector3(movementVector);
        rb.AddForce(speed*movement);
        Debug.Log("当前力: " + movement);
    }
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Pickup")){
            other.gameObject.SetActive(false);
            ++count;SetCountText();
        }
    }
    void SetCountText(){
        countText.text="Count: "+count.ToString();
        if(count==8){
            winTextObject.gameObject.SetActive(true);
        }
    }
}
