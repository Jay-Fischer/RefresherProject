using UnityEngine;

public class DoorScript : MonoBehaviour
{
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void OpenDoor(){
        animator.SetTrigger("Open");
    }

    public void CloseDoor(){
        animator.SetTrigger("Close");
    }


}
