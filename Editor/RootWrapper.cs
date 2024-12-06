using System.Reflection;

namespace ShackLab.OpenUPM.Editor
{
    internal class RootWrapper
    {
        private readonly object _rootObject;
        private readonly PropertyInfo _addMenuProperty;

        public RootWrapper(object rootObject)
        {
            _rootObject = rootObject;
            _addMenuProperty = _rootObject.GetType().GetProperty("addMenu", BindingFlags.Instance | BindingFlags.Public);
        }

        public object AddMenu => _addMenuProperty.GetValue(_rootObject);
    }
}
