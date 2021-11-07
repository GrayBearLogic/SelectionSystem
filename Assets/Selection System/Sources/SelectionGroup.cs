using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

namespace SelectionSystem
{
    /// <summary>
    /// Group of selectable objects.
    /// </summary>
    [AddComponentMenu("Selectable System/Selection Group")]
    public class SelectionGroup : MonoBehaviour
    {
        /// <summary>
        /// Allow selecting no object
        /// </summary>
        public bool allowNoneSelected = true;
        /// <summary>
        /// Allow selecting multiple objects.
        /// </summary>
        public bool multipleSelection;
        
        /// <summary>
        /// Object that will be selected on start.
        /// </summary>
        public SelectableComponent firstSelected;

        /// <summary>
        /// Is called every time when any object is selected or deselected.
        /// </summary>
        public UnityEvent<SelectionGroup> selectionChanged;

        internal readonly List<SelectableComponent> SelectedItems =
            new List<SelectableComponent>();

        /// <summary>
        /// Collection of selected items.
        /// </summary>
        public IEnumerable<SelectableComponent> AllSelected
        {
            get => SelectedItems;
        }

        /// <summary>
        /// Last selected item. Returns null if no object selected.
        /// </summary>
        public SelectableComponent Selected
        {
            get => SelectedItems.Count > 0 
                ? SelectedItems[SelectedItems.Count - 1] 
                : null;
        }
        
        private void Awake()
        {
            if (allowNoneSelected == false)
            {
                firstSelected.Select();
            }
        }

    }
}