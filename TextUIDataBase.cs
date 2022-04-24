using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextUIDataBase : MonoBehaviour
{
   [SerializeField]
    public Text[] names;

    [SerializeField]
    public Text[] qty;

    [SerializeField]
    public Text[] price;

    [SerializeField]
    public Text[] priceUSD;
}
