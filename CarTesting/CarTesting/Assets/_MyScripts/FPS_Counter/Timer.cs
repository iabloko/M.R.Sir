using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text TimerText;
    public float Minutes;
    public float Seconds;



    private void Start()
    {
        StartCoroutine(Wait());
    }
     void Update()
     {

        if (Seconds < 10)
         {
         TimerText.text = (Minutes + ":0" + Seconds);
         }
         if(Seconds > 9)
         {
             TimerText.text = (Minutes + ":" + Seconds);
         }

     }
     public void CountDown()
     {
        if (Seconds >= 59)
         {
            PlusMinute();
             Seconds = 0;
         }
         if(Minutes >= 0)
         {
             PlusSeconds();
         }
         if(Minutes <= 0 && Seconds <= 0)
         {
             Debug.Log("Time Up");
             StopTimer();
         }
         else
         {
             Start ();
         }

     }
     public void PlusMinute()
     {
         Minutes += 1;
     }
     public void PlusSeconds()
     {
         Seconds += 1;
     }
     public IEnumerator Wait()
     {
         yield return new WaitForSeconds(1);
         CountDown();
     }

     public void StopTimer()
     {
         Seconds = 0;
         Minutes = 0;
     }


}
