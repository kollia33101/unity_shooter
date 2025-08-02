using UnityEngine;

public class NewMonoBehaviourScript1 : MonoBehaviour
{public GameObject player; 
 public float speed = 5;
  

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position)>0){
            transform.LookAt(player.transform,Vector3.up);}
    }
}
