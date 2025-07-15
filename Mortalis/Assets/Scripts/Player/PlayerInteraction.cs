using DoorScript;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public float playerReach = 3f;
    public bool hasKeys;
    private Interactable currentInteractable;
    public Camera cameraMain;

    private HasKeys hasKeysScript;

    private RaycastHit hit; // ahora es accesible desde cualquier método de esta clase
    private Ray ray;
    private Item itemScript;
    private Door doorScript;
    private bool alreadyDisabled = false;
    AudioSource audioSource;
    public AudioClip audioKey;


    void Start()
    {
        itemScript = GameObject.FindWithTag("PickUp").GetComponent<Item>();
        hasKeysScript = GameObject.Find("ConditionsManager").GetComponent<HasKeys>();
        doorScript = GameObject.Find("Door").GetComponent<Door>();
        audioSource = GameObject.Find("Player").GetComponent<AudioSource>();
        
    }
    void Update()
    {
        CheckInteraction();
        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            currentInteractable.Inteact();
        }
        if (doorScript.open && !alreadyDisabled)
        {
            hasKeysScript.DisableKeyObject();
            alreadyDisabled = true;
            audioSource.PlayOneShot(audioKey);
        
        }
      
    }
     void CheckInteraction()
    {
        
        Ray ray = new Ray(cameraMain.transform.position, cameraMain.transform.forward);
        if (Physics.Raycast(ray, out hit, playerReach))
        {
            if (hit.collider.tag == "Interactable"  || hit.collider.tag == "PickUp")
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

        if (Physics.Raycast(ray, out hit, playerReach))
        {
            if (hit.transform.GetComponent<DoorScript.Door>())

            {

                if (Input.GetKeyDown(KeyCode.E) && !hasKeysScript.hasKeys1)
                {
                    hit.transform.GetComponent<DoorScript.Door>().OpenDoor();
                    
                
                }
                else if (hasKeysScript.hasKeys1)
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
    public void CheckPickUp()
    {
        if (Physics.Raycast(ray, out hit, playerReach))
        {
            if (hit.transform.tag == "PickUp" )
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.transform.GetComponent<Item>().AddInventory();


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
