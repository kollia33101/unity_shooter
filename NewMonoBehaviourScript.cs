using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
 public float moveSpeed = 5f; // Скорость движения
public float lookSpeed = 2f; // Скорость поворота мыши
public Camera playerCamera; // Камера для отображения от первого лица

public bool onground = false;
public GameObject rifle;
public GameObject pistol;

private float rotationX = 0f; // Угол поворота по X
void OnCollisionEnter(Collision other){ onground = true;
Debug.Log(onground); 
} 


void OnCollisionExit(Collision other){ onground = false;
Debug.Log(onground);
}



void Start()
{
Cursor.lockState = CursorLockMode.Locked; // Скрываем курсор
}

void Update()
{
Move();
RotateView();
shoot();
ChangeWeapons();
}
void shoot(){
	if (Input.GetKey(KeyCode.E)){Transform animator = transform.GetChild(0).GetChild(0);
animator.GetComponent<Animation>().Play("New Animation");}
}
void ChangeWeapons(){
	if(Input.GetKey(KeyCode.V)){//if (Input.GetKey(KeyCode.WheelUp)||Input.GetKey(KeyCode.WheelDown)){
	Debug.Log("yes");
	if (rifle.activeSelf){
		pistol.SetActive(true);
		rifle.SetActive(false); 
    
 	} else {
 		pistol.SetActive(false);
 		rifle.SetActive(true);
 	}
	}
}
void Move()
{
float moveHorizontal = Input.GetAxis("Horizontal");
float moveVertical = Input.GetAxis("Vertical");
if (Input.GetKey(KeyCode.Space)&&onground == true){GetComponent<Rigidbody>().AddForce(Vector3.up*100);}

Vector3 movement = transform.right * moveHorizontal + transform.forward * moveVertical;
transform.position += movement * moveSpeed * Time.deltaTime; // Перемещение персонажа
}

void RotateView()
{
float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

rotationX -= mouseY;
rotationX = Mathf.Clamp(rotationX, -80f, 80f); // Ограничение угла поворота по Y

playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f); // Поворот камеры
transform.Rotate(Vector3.up * mouseX); // Поворот персонажа
}
}
