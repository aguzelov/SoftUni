namespace SIS.Framework.Utilities
{
    public static class ControllerUtilities
    {
        public static string GetControllerName(object controller)
        {
            var controllerName = controller.GetType()
                .Name
                .Replace(MvcContext.Get.ControllersSuffix, string.Empty);

            return controllerName;
        }

        public static string GetViewFullQualifiedName(string controller, string action)
        {
            var fullyQualifiedName = string.Format("{0}\\{1}\\{2}",
                                                    MvcContext.Get.ViewFolder,
                                                    controller,
                                                    action);

            return fullyQualifiedName;
        }
    }
}