using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Define an interface
public interface IEvBase
{
    float timer
    {
        get;set;
    }
    string id{
        get;
    }
    void ev_start();
    bool ev_loop();
    void ev_end();
}
