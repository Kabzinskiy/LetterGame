using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Panels
{
    public interface IPanelItem
    {
        public int Id { get; set; }
        public GameObject GameObject { get; }
}
}
