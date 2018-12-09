﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{

    public delegate void Event();
    public delegate void Event<A>(A arg1);

    // Two examples how to add new events:
    //
    //public static Event NewEvent;
    //public static void RaiseEventNewEvent()
    //{
    //    if (NewEvent != null) NewEvent();
    //}
    //
    //public static Event<int, bool> NewEvent;
    //public static void RaiseEventNewEvent(int howMany, bool isFinal)
    //{
    //    if (NewEvent != null) NewEvent(howMany, isFinal);
    //}

    public static Event EventMenuLoaded;
    public static void RaiseEventMenuLoaded()
    {
        if (EventMenuLoaded != null) EventMenuLoaded();
    }

    public static Event EventGameStarted;
    public static void RaiseEventGameStarted()
    {
        if (EventGameStarted != null) EventGameStarted();
    }

    public static Event EventGameOver;
    public static void RaiseEventGameOver()
    {
        if (EventGameOver != null) EventGameOver();
    }

    public static Event EventGameResumed;
    public static void RaiseEventGameResumed()
    {
        if (EventGameResumed != null) EventGameResumed();
    }

    public static Event EventGemsSubstracted;
    public static void RaiseEventGemsSubstracted()
    {
        if (EventGemsSubstracted != null) EventGemsSubstracted();
    }

    public static Event EventChooseBall;
    public static void RaiseEventChooseBall()
    {
        if (EventChooseBall != null) EventChooseBall();
    }
}
