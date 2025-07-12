using UnityEngine;

public class HasKeys : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool hasKeys1 = false;

    public void DisableKeyObject()
    {
        MeshRenderer mesh = GameObject.Find("RustKeyObject").GetComponent<MeshRenderer>();
        mesh.enabled = false;
    }
}
