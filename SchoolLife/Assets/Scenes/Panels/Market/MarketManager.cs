using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketManager : Button
{
    public bool PublicIsPressed()
    {
        return base.IsPressed();
    }
}
