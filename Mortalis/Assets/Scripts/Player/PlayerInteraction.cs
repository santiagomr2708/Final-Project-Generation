using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public float playerReach = 3f;
    public bool hasKeys;
    private Interactable currentInteractable;
    public Camera cameraMain;


    // Update is called once per frame
    void Update()
    {
        CheckInteraction();
        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            currentInteractable.Inteact();
            if (currentInteractable != null && currentInteractable.CompareTag("Llaves"))
            {
                hasKeys = true;
            }
        }
        
    }

    void CheckInteraction()
    {
        RaycastHit hit;
        Ray ray = new Ray(cameraMain.transform.position, cameraMain.transform.forward);
        if (Physics.Raycast(ray, out hit, playerReach))
        {
            if (hit.collider.tag == "Interactable" || hit.collider.tag == "Llaves")
            {
                
                Interactable newInteractable = hit.collider.GetComponent<Interactable>();
                if (currentInteractable && newInteractable != currentInteractable)
                {
                    currentInteractable.DisableOutLine();
                }
                if (newInteractable.enabled)
                {
                    SetNewCurrentInteractable(newInteractable);
                }
                else DisableCurrentInteractable();
            }
            else DisableCurrentInteractable();
        }
        else DisableCurrentInteractable();

        if (Physics.Raycast (ray, out hit, playerReach)) {
            if (hit.transform.GetComponent<DoorScript.Door>())

            {

                if (Input.GetKeyDown(KeyCode.E) && hasKeys == true)
                {
                    hit.transform.GetComponent<DoorScript.Door>().OpenDoor();


                }
                else if (!hasKeys)
                {
                    hudControlller.instance.EnableInteraction(currentInteractable.message + " (E)");
                }
                else
                {
                    hudControlller.instance.EnableInteraction("It can't be opened");
                }
               
                    
			}   
			
		}
    }

    void SetNewCurrentInteractable(Interactable newInteractable)
    {
        currentInteractable = newInteractable;
        currentInteractable.EnableOutLine();
        hudControlller.instance.EnableInteraction(currentInteractable.message + " (E)");
    }

    void DisableCurrentInteractable()
    {
        hudControlller.instance.DisableInteractionText();
        if(currentInteractable)
        {
            
            currentInteractable.DisableOutLine();
            currentInteractable = null;


        }
      
        
        
    }
    
}
