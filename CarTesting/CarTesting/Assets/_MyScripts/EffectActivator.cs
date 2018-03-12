using UnityEngine;
using Colorful;

    public class EffectActivator : MonoBehaviour
    {
    //---------------------------------------------------------------//
    private Glitch New_glitch;//        ADD
    private RGBSplit New_RGBSplit;//    New
    //private Frost New_Frost;//          Effects
    //---------------------------------------------------------------//
    private float t = 0;
    private bool Active = false;
    private bool Deactive = false;

    private float SIspeed = 5, SIdensity = 20, SImDisp = 10;
    private float STspeed = 0.7f, STintensity = 0.25f, STmDisp = 0.05f, STyuvOffset = 0.5f;
    private bool STyuvColorBleeding = true;
    private float RBGamount = 15, RGBangle = 30;


        private void Awake()
    {
        New_glitch = GetComponent<Glitch>();
        New_RGBSplit = GetComponent<RGBSplit>();
        //New_Frost = GetComponent<Frost>();

    DangerZone.TriggerEnterOn += ADD_Effect;
    DangerZone.TriggerEnterOff += Off_Effect;
    }
        public void ADD_Effect()
    {
        t = 0;
        Active = true;
        Deactive = false;

    //---------------------------------------------------------------//
        STyuvColorBleeding = true;
        New_glitch.SettingsTearing.YuvColorBleeding = STyuvColorBleeding;
    }
        public void Off_Effect()
    {
        t = 0;
        Deactive = true;
        Active = false;

            //---------------------------------------------------------------//
        STyuvColorBleeding = false;
        New_glitch.SettingsTearing.YuvColorBleeding = STyuvColorBleeding;
    }

        private void FixedUpdate()
    {
        if (Active == true && t < 1.2f)
        {
        SIspeed = Mathf.Lerp(0, 5, t);
        New_glitch.SettingsInterferences.Speed = SIspeed;
        SIdensity = Mathf.Lerp(0, 20, t);
        New_glitch.SettingsInterferences.Density = SIdensity;
        SImDisp = Mathf.Lerp(0, 10, t);
        New_glitch.SettingsInterferences.MaxDisplacement = SImDisp;

        STspeed = Mathf.Lerp(0, 0.7f, t);
        New_glitch.SettingsTearing.Speed = STspeed;
        STintensity = Mathf.Lerp(0, 0.25f, t);
        New_glitch.SettingsTearing.Intensity = STintensity;
        STmDisp = Mathf.Lerp(0, 0.05f, t);
        New_glitch.SettingsTearing.MaxDisplacement = STmDisp;
        STyuvOffset = Mathf.Lerp(0, 0.5f, t);
        New_glitch.SettingsTearing.YuvOffset = STyuvOffset;

        RBGamount = Mathf.Lerp(0, 15, t);
        New_RGBSplit.Amount = RBGamount;
        RGBangle = Mathf.Lerp(0, 30, t);
        New_RGBSplit.Angle = RGBangle;
        t += 0.5f * Time.deltaTime;
        }

        if (Deactive == true && (0 <= t && t < 1.2f))
        {
        SIspeed = Mathf.Lerp(5, 0, t);
        New_glitch.SettingsInterferences.Speed = SIspeed;
        SIdensity = Mathf.Lerp(20, 0, t);
        New_glitch.SettingsInterferences.Density = SIdensity;
        SImDisp = Mathf.Lerp(10, 0, t);
        New_glitch.SettingsInterferences.MaxDisplacement = SImDisp;

        STspeed = Mathf.Lerp(0.7f, 0, t);
        New_glitch.SettingsTearing.Speed = STspeed;
        STintensity = Mathf.Lerp(0.25f, 0, t);
        New_glitch.SettingsTearing.Intensity = STintensity;
        STmDisp = Mathf.Lerp(0.05f, 0, t);
        New_glitch.SettingsTearing.MaxDisplacement = STmDisp;
        STyuvOffset = Mathf.Lerp(0.5f, 0, t);
        New_glitch.SettingsTearing.YuvOffset = STyuvOffset;

        RBGamount = Mathf.Lerp(15, 0, t);
        New_RGBSplit.Amount = RBGamount;
        RGBangle = Mathf.Lerp(30, 0, t);
        New_RGBSplit.Angle = RGBangle;

        t += 0.5f * Time.deltaTime;
        }
    }
}
