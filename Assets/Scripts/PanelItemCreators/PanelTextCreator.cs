using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Panels
{
    public class PanelTextCreator : IItemsCreator
    {
        string PATH = "Prefabs/Letter";
        public IPanelItem Create(MonoBehaviour monoBehaviour) 
        { 
            var prefab = Resources.Load<GameObject>(PATH);
            return Object.Instantiate(prefab, monoBehaviour.gameObject.transform).GetComponent<PanelText>();
        }
    }
}
