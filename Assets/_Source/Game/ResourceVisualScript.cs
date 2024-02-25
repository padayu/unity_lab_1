using System;
using _Source.Core;
using UnityEngine;
using TMPro;

namespace _Source.Game
{
    public class ResourceVisualScript : MonoBehaviour
    {
        public GameResource displayedResourceType;
        public GameObject gameManager;
        public TextMeshProUGUI text;
        private ObservableInt _resourceAmount;

        private void Start()
        {
            if (gameManager.TryGetComponent(out GameManagerScript script))
            {
                _resourceAmount = script.GetResource(displayedResourceType);
                _resourceAmount.OnValueChanged += UpdateText;
                UpdateText(_resourceAmount.Value);
            }
        }

        private void UpdateText(int value)
        {
            text.SetText(Enum.GetName(typeof(GameResource), displayedResourceType) + '\n' + value.ToString());
        }
    }
}
