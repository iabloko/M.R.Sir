using UnityEngine;
public class DangerZone : MonoBehaviour
{
    public GameObject _Buggy;
    //--------------------------------------------------------------------//
    public delegate void Action_OnTriggerEnterOn();
    public static event Action_OnTriggerEnterOn TriggerEnterOn;
    //--------------------------------------------------------------------//
    public delegate void Deactivation_OnTriggerEnterOff();
    public static event Deactivation_OnTriggerEnterOff TriggerEnterOff;
    //--------------------------------------------------------------------//

    private void OnTriggerEnter(Collider _Buggy)
    {
        if(_Buggy.gameObject.tag == "Player")
        TriggerEnterOn.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (_Buggy.gameObject.tag == "Player")
        TriggerEnterOff.Invoke();
    }
}
