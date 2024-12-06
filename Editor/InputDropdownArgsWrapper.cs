using System;
using System.Reflection;

namespace ShackLab.OpenUPM.Editor
{
    internal class InputDropdownArgsWrapper
    {
        private static readonly Type _type;
        private readonly object _instance;
        private readonly FieldInfo _titleField;
        private readonly FieldInfo _iconUssClassField;
        private readonly FieldInfo _placeholderTextField;
        private readonly FieldInfo _submitButtonTextField;
        private readonly FieldInfo _onInputSubmittedField;

        static InputDropdownArgsWrapper()
        {
            _type = Type.GetType(
                "UnityEditor.PackageManager.UI.InputDropdownArgs, UnityEditor.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null");
        }

        public InputDropdownArgsWrapper()
        {
            _instance = Activator.CreateInstance(_type);
            _titleField = _type.GetField("title", BindingFlags.Instance | BindingFlags.Public);
            _iconUssClassField = _type.GetField("iconUssClass", BindingFlags.Instance | BindingFlags.NonPublic);
            _placeholderTextField = _type.GetField("placeholderText", BindingFlags.Instance | BindingFlags.Public);
            _submitButtonTextField = _type.GetField("submitButtonText", BindingFlags.Instance | BindingFlags.Public);
            _onInputSubmittedField = _type.GetField("onInputSubmitted", BindingFlags.Instance | BindingFlags.Public);
        }

        public object Instance => _instance;

        public string Title
        {
            get => (string)_titleField.GetValue(_instance);
            set => _titleField.SetValue(_instance, value);
        }

        public string IconUssClass
        {
            get => (string)_iconUssClassField.GetValue(_instance);
            set => _iconUssClassField.SetValue(_instance, value);
        }

        public string PlaceholderText
        {
            get => (string)_placeholderTextField.GetValue(_instance);
            set => _placeholderTextField.SetValue(_instance, value);
        }

        public string SubmitButtonText
        {
            get => (string)_submitButtonTextField.GetValue(_instance);
            set => _submitButtonTextField.SetValue(_instance, value);
        }

        public Action<string> OnInputSubmitted
        {
            get => (Action<string>)_onInputSubmittedField.GetValue(_instance);
            set => _onInputSubmittedField.SetValue(_instance, value);
        }
    }
}