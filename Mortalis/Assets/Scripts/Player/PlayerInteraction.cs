using UnityEngine;
using UnityEngine.InputSystem;
using DoorScript;

public class PlayerInteraction : MonoBehaviour
{
    public float playerReach = 3f;
    public bool hasKeys;
    private Interactable currentInteractable;
    public Camera cameraMain;

    private HasKeys hasKeysScript;

    private RaycastHit hit;
    private Ray ray;
    private Item itemScript;
    private Door doorScript;
    private bool alreadyDisabled = false;
    public AudioClip audioKey;

    private PlayerInput playerInput;
    private InputAction interactAction;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        interactAction = playerInput.actions["Interact"];
    }

    void Start()
    {
        itemScript = GameObject.FindWithTag("PickUp").GetComponent<Item>();
        hasKeysScript = GameObject.Find("ConditionsManager").GetComponent<HasKeys>();
        doorScript = GameObject.Find("Door").GetComponent<Door>();
    }

    void Update()
    {
        CheckInteraction();

        if (doorScript.open && !alreadyDisabled)
        {
            hasKeysScript.DisableKeyObject();
            alreadyDisabled = true;
            SoundFXManager.instance.PlaySoundFXClip(audioKey, transform, 1f, false);
        }
    }

    void OnInteract()
    {
        if (currentInteractable != null)
        {
            Door door = currentInteractable.GetComponent<Door>();
            if (door != null)
            {
                if (hasKeysScript.hasKeys1)
                {
                    door.OpenDoor();
                }
                else
                {
                    hudControlller.instance.EnableInteraction("It can't be opened");
                }
                return; // salimos para no hacer doble interacción
            }
            currentInteractable.Inteact();
        }
    }

    void CheckInteraction()
    {
        ray = new Ray(cameraMain.transform.position, cameraMain.transform.forward);
        if (Physics.Raycast(ray, out hit, playerReach))
        {
            if (hit.collider.CompareTag("Interactable") || hit.collider.CompareTag("PickUp"))
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
    }

    void SetNewCurrentInteractable(Interactable newInteractable)
    {
        currentInteractable = newInteractable;
        currentInteractable.EnableOutLine();
        if (currentInteractable.GetComponent<Door>() && !hasKeysScript.hasKeys1)
        {
            hudControlller.instance.EnableInteraction("It can't be opened");
        }
        else
        {
            hudControlller.instance.EnableInteraction(currentInteractable.message + " (" + GetInteractBinding() + ")");

        }
    }

    void DisableCurrentInteractable()
    {
        hudControlller.instance.DisableInteractionText();
        if (currentInteractable)
        {
            currentInteractable.DisableOutLine();
            currentInteractable = null;
        }
    }

    string GetInteractBinding()
    {
        // Encuentra la primera binding activa (puedes ajustar para múltiples dispositivos si lo necesitas)
        var bindingIndex = interactAction.GetBindingIndexForControl(interactAction.controls[0]);
        var bindingDisplay = InputControlPath.ToHumanReadableString(
            interactAction.bindings[bindingIndex].effectivePath,
            InputControlPath.HumanReadableStringOptions.OmitDevice);

        return bindingDisplay;
    }
}
