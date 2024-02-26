#pragma warning disable CS8602 // Dereference of a possibly null reference.
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

            Items.Add(new ToolStripSeparator());
            Items.Add(new ToolStripButton() { Name = "bindingNavigatorAboutItem", Text = "About"});
        }

        /// <summary>
        /// Prohibit adding new items
        /// </summary>
        public void DisableAddButton()
        {
            AddNewItem.Enabled = false;
        }

        /// <summary>
        /// Prohibit deleting items
        /// </summary>
        public void DisableRemoveButton()
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

        /// <summary>
        /// Remove default actions for delete and add buttons
        /// </summary>
        public void RemoveDefaultHandlers()
        {
            AddNewItem = null;
            DeleteItem = null;
        }

        /// <summary>
        /// Provide access to the add new button
        /// </summary>
        public ToolStripItem AddItemButton => Items["bindingNavigatorAddNewItem"]!;
        /// <summary>
        /// Provides access to the delete current row
        /// </summary>
        public ToolStripItem DeleteItemButton => Items["bindingNavigatorDeleteItem"]!;
        public ToolStripItem AboutItemButton => Items["bindingNavigatorAboutItem"]!;
    }
}
