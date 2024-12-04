#if UNITY_EDITOR
using System;
using UnityEditor;
using Debug = UnityEngine.Debug;

namespace ShackLab.OpenUPM.Editor
{
    [InitializeOnLoad]
    public static class OpenUPM
    {
        static OpenUPM()
        {
            EditorApplication.delayCall += Update;
        }

        private static void Update()
        {
            var packageInstance = PackageManagerWindowWrapper.Instance;

            if (packageInstance != null)
            {
                HandlePackageManagerReady();
            }
            else
            {
                PackageManagerWindowWrapper.AddOnPackageManagerReadyHandler(HandlePackageManagerReady);
            }
        }

        private static void HandlePackageManagerReady()
        {
            var root = PackageManagerWindowWrapper.Root;
            var rootWrapper = new RootWrapper(root);
            var addMenuWrapper = new AddMenuWrapper(rootWrapper.AddMenu);

            var dropdownItemWrapper = new DropdownItemWrapper(addMenuWrapper.AddBuiltInDropdownItem());
            PopulateDropdown(dropdownItemWrapper, addMenuWrapper);
        }

        private static void PopulateDropdown(DropdownItemWrapper dropdownItemWrapper, AddMenuWrapper addMenuWrapper)
        {
            dropdownItemWrapper.Text = "Install package from OpenUPM...";
            Action originalAction = dropdownItemWrapper.Action;
            dropdownItemWrapper.Action = originalAction + OnClick;

            void OnClick()
            {
                var inputDropdownArgsWrapper = new InputDropdownArgsWrapper();
                inputDropdownArgsWrapper.Title = L10n.Tr("Add package using package name");
                inputDropdownArgsWrapper.IconUssClass = "git";
                inputDropdownArgsWrapper.PlaceholderText = L10n.Tr("name");
                inputDropdownArgsWrapper.SubmitButtonText = L10n.Tr("Add");
                Action<string> originalOnInputSubmitted = inputDropdownArgsWrapper.OnInputSubmitted;
                inputDropdownArgsWrapper.OnInputSubmitted = originalOnInputSubmitted + OnInputSubmitted;

                addMenuWrapper.ShowInputDropdown(inputDropdownArgsWrapper.Instance);
            }

            void OnInputSubmitted(string package)
            {
                package = Utility.NormalizeCommand(package);

                if (Utility.IsValidPackageName(package))
                {
                    CommandLineUtility.RunCommand($"openupm add \"{package}\"").ConfigureAwait(false);
                }
                else
                {
                    Debug.LogError($"Invalid package name: {package}");
                }
            }
        }




    }
}
#endif
