using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Panels
{
    public interface IItemsCreator
    {
        public IPanelItem Create(MonoBehaviour monoBehaviour);
    }
}
