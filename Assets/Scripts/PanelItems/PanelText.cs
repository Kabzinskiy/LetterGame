using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Panels
{
    public class PanelText : MonoBehaviour, IPanelItem
    {
        public int Id { get; set; }
        public GameObject GameObject => Text.gameObject;
        public Text Text => GetComponent<Text>();
    }
}
