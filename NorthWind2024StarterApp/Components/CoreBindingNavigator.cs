
namespace NorthWind2024StarterApp.Components
{
    /// <summary>
    /// VS2019 there is no BindingNavigator, here you go :-)
    /// </summary>
    public sealed class CoreBindingNavigator : BindingNavigator
    {
        public CoreBindingNavigator()
        {
            AddStandardItems();
        }

        /// <summary>
        /// Prohibit adding new items
        /// </summary>
        public void DisableAddNewItems()
        {
            AddNewItem.Enabled = false;
        }

        /// <summary>
        /// Prohibit deleting items
        /// </summary>
        public void DisableRemoveItems()
        {
            DeleteItem.Enabled = false;
        }

        /// <summary>
        /// Enable Adding new items
        /// </summary>
        public void EnableAddNewItems()
        {
            AddNewItem.Enabled = true;
        }

        /// <summary>
        /// Enable removing items
        /// </summary>
        public void EnableRemoveItems()
        {
            DeleteItem.Enabled = true;
        }
    }
}
