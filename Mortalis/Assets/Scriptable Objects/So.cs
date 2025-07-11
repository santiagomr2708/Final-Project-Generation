using UnityEngine;
[CreateAssetMenu]
public class So : ScriptableObject
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string itemName;
    public StatToChange statToChange = new StatToChange();
    public AttributesToChange attributesToChange= new AttributesToChange();
    public int amountToChangeStat;
    

    public void UseItem()
    {
        if (statToChange == StatToChange.hasKeys)
        {
            GameObject.Find("ConditionsManager").GetComponent<HasKeys>().hasKeys1 = true;
            MeshRenderer mesh = GameObject.Find("RustKeyObject").GetComponent<MeshRenderer>();
            mesh.enabled = true;
            Debug.Log("sitienellaves");
        }
    }


    public enum StatToChange
    {
       none,
       speed,
        hasKeys,
    };
    public enum AttributesToChange
    {
        speed,
        hasKeys,
    };
}
