using UnityEngine;

public class RabbitController : MonoBehaviour
{
    Rabbit rabbit;
    public bool run;
    public bool idle;

    // Start is called before the first frame update
    void Start()
    {
        if (run == true)
        {
            rabbit.run();
        }
        //if (run == true)
        //{
        //    rabbit.idle();
        //}
        
    }

}
