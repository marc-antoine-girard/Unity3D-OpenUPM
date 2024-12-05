using UnityEditor;
using UnityEditor.PackageManager.UI;
using UnityEngine.UIElements;
using PackageInfo = UnityEditor.PackageManager.PackageInfo;

namespace ShackLab.OpenUPM.Editor
{
    [InitializeOnLoad]

    public class CustomPackageManagerExtension : IPackageManagerExtension
    {
        static CustomPackageManagerExtension()
        {
            PackageManagerExtensions.RegisterExtension(new CustomPackageManagerExtension());
        }

        public VisualElement CreateExtensionUI()
        {
            // Create a stub VisualElement
            var element = new VisualElement();

            // Register the AttachToPanelEvent. This gives us a confirmation that the Package Manager UI is opened
            element.RegisterCallback<AttachToPanelEvent>(_ => { OpenUPM.Update(); });

            return element;
        }

        public void OnPackageSelectionChange(PackageInfo packageInfo)
        {
        }

        public void OnPackageAddedOrUpdated(PackageInfo packageInfo)
        {
        }

        public void OnPackageRemoved(PackageInfo packageInfo)
        {
        }
    }
}