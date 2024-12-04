#if UNITY_EDITOR
using System.Reflection;

namespace ShackLab.OpenUPM.Editor
{
    public class AddMenuWrapper
    {
        private readonly object _addMenuObject;
        private readonly MethodInfo _addBuiltInDropdownItemMethod;
        private readonly MethodInfo _showInputDropdownMethod;

        public AddMenuWrapper(object addMenuObject)
        {
            _addMenuObject = addMenuObject;
            var type = _addMenuObject.GetType();
            _addBuiltInDropdownItemMethod = type.GetMethod("AddBuiltInDropdownItem", BindingFlags.Instance | BindingFlags.Public);
            _showInputDropdownMethod = type.GetMethod("ShowInputDropdown", BindingFlags.Instance | BindingFlags.Public);
        }

        public object AddBuiltInDropdownItem()
        {
            return _addBuiltInDropdownItemMethod.Invoke(_addMenuObject, null);
        }

        public void ShowInputDropdown(object inputDropdownArgs)
        {
            _showInputDropdownMethod.Invoke(_addMenuObject, new[] { inputDropdownArgs });
        }
    }
}
#endif