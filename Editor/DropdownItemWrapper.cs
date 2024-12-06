using System;
using System.Reflection;

namespace ShackLab.OpenUPM.Editor
{
    internal class DropdownItemWrapper
    {
        private readonly object _dropdownItemObject;
        private readonly PropertyInfo _textProperty;
        private readonly PropertyInfo _actionProperty;

        public DropdownItemWrapper(object dropdownItemObject)
        {
            _dropdownItemObject = dropdownItemObject;
            var type = _dropdownItemObject.GetType();
            _textProperty = type.GetProperty("text", BindingFlags.Instance | BindingFlags.Public);
            _actionProperty = type.GetProperty("action", BindingFlags.Instance | BindingFlags.Public);
        }

        public string Text
        {
            get => (string)_textProperty.GetValue(_dropdownItemObject);
            set => _textProperty.SetValue(_dropdownItemObject, value);
        }

        public Action Action
        {
            get => (Action)_actionProperty.GetValue(_dropdownItemObject);
            set => _actionProperty.SetValue(_dropdownItemObject, value);
        }
    }
}
