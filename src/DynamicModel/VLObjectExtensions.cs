using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VL.Lib.Collections;

namespace VL.Core
{
    public static class VLObjectExtensions
    {
        const string PATH = "Path";
        const string INDEX = "Index";

        public static T GeneratePaths<T>(this T instance) where T : IVLObject
        {
            return (T)instance.GeneratePaths_("", 0);
        }
        /**
         * Kairos_M
         *   - PATH = ""
         *   - Timeline_M
         *     - PATH = "Timeline_M"
         *     - Tracks
         *       - 0
         *         - PATH = "Timeline_M.Tracks[0]"
         *         - Clips
         *           - 0
         *             - PATH = "Timeline_M.Tracks[0].Clips[0]"
         *             - Position
         *             - Duration
         *             - Item_M
         *               - Value
         *               - Node_M
         */
        static IVLObject GeneratePaths_(this IVLObject instance, string currentPath, int index)
        {
            var typeInfo = instance.Type;
            foreach (var property in typeInfo.Properties)
            {
                var name = property.Name;
                var type = property.Type.ClrType;
                if (name == PATH && type == typeof(string))
                {
                    var p = property.GetValue(instance) as string;
                    if (p != currentPath)
                        instance = property.WithValue(instance, currentPath);
                    continue;
                }
                if (name == INDEX && type == typeof(int))
                {
                    var i = (int)property.GetValue(instance);
                    if (i != index)
                        instance = property.WithValue(instance, index);
                    continue;
                }
                var propertyPath = string.IsNullOrWhiteSpace(currentPath) ? name : $"{currentPath}.{name}";
                var value = property.GetValue(instance);
                var vlObject = value as IVLObject;
                if (vlObject != null)
                {
                    var v = vlObject.GeneratePaths_(propertyPath, 0) as IVLObject;
                    if (v != vlObject)
                        instance = property.WithValue(instance, v);
                    continue;
                }
                var spread = value as ISpread;
                if (spread != null)
                {
                    for (int i = 0; i < spread.Count; i++)
                    {
                        var vlSlice = spread.GetItem(i) as IVLObject;
                        if (vlSlice != null)
                        {
                            var newSlice = vlSlice.GeneratePaths_($"{propertyPath}[{i}]", i) as IVLObject;
                            if (newSlice != vlSlice)
                                spread = spread.SetItem(i, newSlice);
                        }
                    }
                    if (spread != value)
                        instance = property.WithValue(instance, spread);
                    continue;
                }
            }
            return instance;
        }
    }
}
