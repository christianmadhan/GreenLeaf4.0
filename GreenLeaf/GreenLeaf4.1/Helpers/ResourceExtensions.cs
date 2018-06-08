using System;
using System.Runtime.InteropServices;

using Windows.ApplicationModel.Resources;

namespace GreenLeaf4._1.Helpers
{

    // Not Sure what this does yet.
    // But we are using it :D
    internal static class ResourceExtensions
    {
        private static ResourceLoader _resLoader = new ResourceLoader();

        public static string GetLocalized(this string resourceKey)
        {
            return _resLoader.GetString(resourceKey);
        }
    }
}
