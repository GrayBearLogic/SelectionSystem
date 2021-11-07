using UnityEngine.Events;
using UnityEngine;

namespace SelectionSystem
{
    /// <summary>
    /// Component that allows the gameObject to be selectable.
    /// </summary>
    [AddComponentMenu("Selectable System/Selectable Component")]
    public class SelectableComponent : MonoBehaviour
    {
        /// <summary>
        /// Group this object belongs to.
        /// </summary>
        public SelectionGroup group;
        
        /// <summary>
        /// Is called when object is selected.
        /// Object can be selected with mouse or with <c>Select</c>
        /// </summary>
        public UnityEvent selected;
        /// <summary>
        /// Is called when object is deselected.
        /// </summary>
        public UnityEvent deselected;
        /// <summary>
        /// Is called when mouse enters the object's collider.
        /// Object can be deselected with mouse or with <c>Deselect</c>
        /// </summary>
        public UnityEvent highlighted;
        /// <summary>
        ///  Is called when mouse leaves the object's collider.
        /// </summary>
        public UnityEvent unhighlighted;

        /// <summary>
        /// Is this object is selected at the moment.
        /// </summary>
        public bool IsSelected
        {
            get;
            private set; 
        }

        private void OnMouseEnter()
        {
            highlighted.Invoke();
        }
        private void OnMouseExit()
        {
            unhighlighted.Invoke();
        }
        private void OnMouseUpAsButton()
        {
            if (IsSelected)
            {
                Deselect();
            }
            else
            {
                Select();
            }
        }

        /// <summary>
        /// Select object without mouse.
        /// </summary>
        public void Select()
        {
            if (IsSelected == false)
            {
                if (group.multipleSelection == false)
                {
                    foreach (var item in group.SelectedItems)
                    {
                        item.IsSelected = false;
                        item.deselected.Invoke();
                    }
                    group.SelectedItems.Clear();
                    
                    group.SelectedItems.Add(this);
                }
                else
                {
                    group.SelectedItems.Add(this);
                    group.selectionChanged.Invoke(group);
                }
                IsSelected = true;
                selected.Invoke();
            }
        }
        /// <summary>
        /// Deselect object without mouse.
        /// </summary>
        public void Deselect()
        {
            if (IsSelected && (group.allowNoneSelected || group.SelectedItems.Count > 1))
            {
                group.SelectedItems.Remove(this);
                if (group.SelectedItems.Count == 0)
                {
                    group.selectionChanged.Invoke(group);
                }
                IsSelected = false;
                deselected.Invoke();
            }
        }
    }
}
