using System;
using System.Reflection;

namespace ShackLab.OpenUPM.Editor
{
    public static class PackageManagerWindowWrapper
    {
        private static readonly Type _type;
        private static readonly PropertyInfo _instanceProperty;
        private static readonly FieldInfo _rootField;

        static PackageManagerWindowWrapper()
        {
            _type = Type.GetType("UnityEditor.PackageManager.UI.PackageManagerWindow, UnityEditor.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null");
            _instanceProperty = _type!.GetProperty("instance", BindingFlags.Static | BindingFlags.NonPublic);
            _rootField = _type.GetField("m_Root", BindingFlags.Instance | BindingFlags.NonPublic);
        }

        public static object Instance => _instanceProperty.GetValue(null);

        public static object Root => _rootField.GetValue(Instance);
    }
}
