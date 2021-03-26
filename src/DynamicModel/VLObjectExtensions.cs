using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using VL.Core;
using VL.Lib.Collections;

namespace Kairos
{
    public static class VLObjectExtensions
    {
        static readonly Regex FValueIndexerRegex = new Regex(@"(.+)\[([0-9]+)\]$", RegexOptions.Compiled);
        static readonly Regex FStringIndexerRegex = new Regex(@"(.+)\[""(.*?)""\]$", RegexOptions.Compiled);

        public static bool TryGetPath(this IVLObject instance, IVLObject descendant, string propertyName, out string path)
        {
            var property = descendant.Type.AllProperties.FirstOrDefault(p => p.Name == propertyName);
            if (property != null)
                return TryGetPath(instance, descendant, property, out path);

            path = null;
            return false;
        }

        public static bool TryGetPath(this IVLObject instance, IVLObject descendant, IVLPropertyInfo property, out string path)
        {
            if (descendant.Type.AllProperties.Contains(property))
            {
                if (instance.Identity == descendant.Identity)
                {
                    path = property.Name;
                    return true;
                }

                if (instance.TryGetPath(descendant, out var subPath))
                {
                    path = $"{subPath}.{property.Name}";
                    return true;
                }
            }

            path = null;
            return false;
        }

        public static bool TryGetPath(this IVLObject instance, IVLObject descendant, out string path)
        {
            if (instance.Identity == descendant.Identity)
            {
                path = "";
                return true;
            }

            foreach (var property in instance.Type.Properties)
            {
                var value = property.GetValue(instance);
                if (value is IVLObject child)
                {
                    if (child.Identity == descendant.Identity)
                    {
                        path = property.Name;
                        return true;
                    }
                    else if (child.TryGetPath(descendant, out var subPath))
                    {

                        path = $"{property.Name}.{subPath}";
                        return true;
                    }
                }
                else if (value is ISpread children)
                {
                    var count = children.Count;
                    for (int i = 0; i < count; i++)
                    {
                        if (children.GetItem(i) is IVLObject obj)
                        {
                            if (obj.Identity == descendant.Identity)
                            {
                                path = $"{property.Name}[{i}]";
                                return true;
                            }
                            else if (obj.TryGetPath(descendant, out var subPath))
                            {
                                path = $"{property.Name}[{i}].{subPath}";
                                return true;
                            }
                        }
                    }
                }
                else if (value is IDictionary dict)
                {
                    var enumerator = dict.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        var entry = enumerator.Entry;
                        if (entry.Value is IVLObject obj)
                        {
                            if (obj.Identity == descendant.Identity)
                            {
                                path = $"{property.Name}[\"{entry.Key}\"]";
                                return true;
                            }
                            else if (obj.TryGetPath(descendant, out string subPath))
                            {
                                path = $"{property.Name}[\"{entry.Key}\"].{subPath}";
                                return true;
                            }
                        }
                    }
                }
            }

            path = null;
            return false;
        }

        /// <summary>
        /// Tries to retrieve the value from the given path. The path is a dot separated string of property names.
        /// </summary>
        /// <typeparam name="T">The expected type of the value.</typeparam>
        /// <param name="instance">The root instance to start the lookup from.</param>
        /// <param name="path">A dot separated string of property names. Spreaded properties can be indexed using [N] for example "MySpread[0]" retrieves the first value in MySpread.</param>
        /// <param name="defaultValue">The default value to use in case the lookup failed.</param>
        /// <param name="value">The returned value.</param>
        /// <returns>True if the lookup succeeded.</returns>
        public static bool TryGetValueByPath<T>(this IVLObject instance, string path, T defaultValue, out T value)
        {
            var spine = instance.GetSpine(path);
            var entry = spine.Pop();
            var leaf = entry.Value;
            return TryGetValueByExpression(leaf, entry.Key, defaultValue, out value);
        }

        /// <summary>
        /// Tries to set the value of the given path. The path is a dot separated string of property names.
        /// </summary>
        /// <typeparam name="TInstance">The type of the instance.</typeparam>
        /// <typeparam name="TValue">The expected type of the value.</typeparam>
        /// <param name="instance">The root instance to start the lookup from.</param>
        /// <param name="path">A dot separated string of property names. Spreaded properties can be indexed using [N] for example "MySpread[0]" sets the first value in MySpread.</param>
        /// <param name="value">The value to set.</param>
        /// <returns>The new root instance (if it is a record) with the updated spine.</returns>
        public static TInstance WithValueByPath<TInstance, TValue>(this TInstance instance, string path, TValue value)
            where TInstance : class, IVLObject
        {
            return ((IVLObject)instance).WithValueByPath(path, value) as TInstance;
        }

        /// <summary>
        /// Whether or not the type is supported by <see cref="TryReplaceDescendant"/>.
        /// </summary>
        public static bool IsSupportedCollectionType(IVLTypeInfo type)
        {
            var clrType = type?.ClrType;
            if (clrType is null)
                return false;
            var arguments = clrType.GenericTypeArguments;
            if (typeof(ISpread).IsAssignableFrom(clrType) && arguments.Length == 1 && typeof(IVLObject).IsAssignableFrom(arguments[0]))
                return true;
            if (typeof(IDictionary).IsAssignableFrom(clrType) && arguments.Length == 2 && typeof(IVLObject).IsAssignableFrom(arguments[1]))
                return true;
            return false;
        }

        /// <summary>
        /// Traverses into the object graph of <paramref name="instance"/> and if it can find a descendant with the same <see cref="IVLObject.Identity"/>
        /// as the given <paramref name="descendant"/> replaces it and outputs a new <paramref name="updatedInstance"/>.
        /// </summary>
        /// <remarks>
        /// Only user defined properties will be traversed. If a property holds many children it must be of type <see cref="ISpread"/> or <see cref="IDictionary"/>. Other collection types will not be looked at.
        /// </remarks>
        /// <typeparam name="TInstance">The type of the instance.</typeparam>
        /// <typeparam name="TDescendant">The type of the descendant.</typeparam>
        /// <param name="instance">The instance to traverse into.</param>
        /// <param name="descendant">The new descendant.</param>
        /// <param name="updatedInstance">The updated instance with the descendant replaced.</param>
        /// <returns>Returns true if a descendant with the same <see cref="IVLObject.Identity"/> as the given one was found and replaced.</returns>
        public static bool TryReplaceDescendant<TInstance, TDescendant>(this TInstance instance, TDescendant descendant, out TInstance updatedInstance)
            where TInstance : class, IVLObject
            where TDescendant : class, IVLObject
        {
            if (instance.Identity == descendant.Identity)
            {
                updatedInstance = descendant as TInstance;
                return true;
            }
            foreach (var property in instance.Type.Properties)
            {
                var value = property.GetValue(instance);
                if (value is IVLObject child)
                {
                    if (child.TryReplaceDescendant(descendant, out var newChild))
                    {
                        if (newChild != child)
                            updatedInstance = property.WithValue(instance, newChild) as TInstance;
                        else
                            updatedInstance = instance;
                        return true;
                    }
                }
                else if (value is ISpread children)
                {
                    var count = children.Count;
                    for (int i = 0; i < count; i++)
                    {
                        if (children.GetItem(i) is IVLObject obj)
                        {
                            if (obj.TryReplaceDescendant(descendant, out var newObj))
                            {
                                if (newObj != obj)
                                {
                                    var updatedChildren = children.SetItem(i, newObj);
                                    updatedInstance = property.WithValue(instance, updatedChildren) as TInstance;
                                }
                                else
                                    updatedInstance = instance;
                                return true;
                            }
                        }
                    }
                }
                else if (value is IDictionary dict)
                {
                    var enumerator = dict.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        var entry = enumerator.Entry;
                        if (entry.Value is IVLObject obj)
                        {
                            if (obj.TryReplaceDescendant(descendant, out var newObj))
                            {
                                if (newObj != obj)
                                {
                                    var updatedDict = SetItem(dict, entry.Key, newObj);
                                    updatedInstance = property.WithValue(instance, updatedDict) as TInstance;
                                }
                                else
                                    updatedInstance = instance;
                                return true;
                            }
                        }
                    }
                }
            }
            updatedInstance = instance;
            return false;
        }


        static IVLObject WithValueByPath<T>(this IVLObject instance, string path, T value)
        {
            var spine = instance.GetSpine(path);

            // Update the leaf with the value
            var entry = spine.Pop();
            var leaf = entry.Value;

            var updatedInstance = leaf.WithValueFromExpression(entry.Key, value);

            // Update the VL objects along the spine
            while (spine.Count > 0)
            {
                entry = spine.Pop();
                updatedInstance = entry.Value.WithValueFromExpression(entry.Key, updatedInstance);
            }

            return updatedInstance;
        }

        static Stack<KeyValuePair<string, IVLObject>> GetSpine(this IVLObject instance, string path)
        {
            var stack = new Stack<KeyValuePair<string, IVLObject>>();
            var p = path.Split('.');
            var current = instance;
            for (int i = 0; i < p.Length; i++)
            {
                stack.Push(new KeyValuePair<string, IVLObject>(p[i], current));
                if (TryGetValueByExpression(current, p[i], default(IVLObject), out var next))
                {
                    current = next;
                }
                else
                {
                    break;
                }
            }
            return stack;
        }

        static bool TryGetValueByExpression<T>(IVLObject instance, string expression, T defaultValue, out T value)
        {
            if (string.IsNullOrWhiteSpace(expression))
            {
                value = defaultValue;
                return false;
            }

            if (TryParseValueIndexer(expression, out var propertyName, out var index))
            {
                if (TryGetValueByExpression(instance, propertyName, default(ISpread), out ISpread spread))
                {
                    var item = spread.GetItem(index);
                    if (item is T)
                    {
                        value = (T)item;
                        return true;
                    }
                }
                value = defaultValue;
                return false;
            }
            else if (TryParseStringIndexer(expression, out propertyName, out var key))
            {
                if (TryGetValueByExpression(instance, propertyName, default(IDictionary), out IDictionary dict))
                {
                    if (dict.Contains(key))
                    {
                        var item = dict[key];
                        if (item is T)
                        {
                            value = (T)item;
                            return true;
                        }
                    }
                }
                value = defaultValue;
                return false;
            }
            else
            {
                return instance.TryGetValue(propertyName, defaultValue, out value);
            }
        }

        static IVLObject WithValueFromExpression<T>(this IVLObject instance, string expression, T value)
        {
            if (string.IsNullOrWhiteSpace(expression))
                return instance;

            if (TryParseValueIndexer(expression, out var propertyName, out var index))
            {
                if (instance.TryGetValue(propertyName, null, out ISpread spread))
                    return instance.WithValue(propertyName, spread.SetItem(index, value));
                return instance;
            }
            if (TryParseStringIndexer(expression, out propertyName, out var key))
            {
                if (instance.TryGetValue(propertyName, null, out IDictionary dict))
                    return instance.WithValue(propertyName, SetItem(dict, key, value));
                return instance;
            }

            return instance.WithValue(propertyName, value);
        }

        static IDictionary SetItem(IDictionary dict, object key, object value)
        {
            var dictType = dict.GetType();
            var toBuilderMethod = dictType.GetMethod(nameof(ImmutableDictionary<string, object>.ToBuilder));
            if (toBuilderMethod != null)
            {
                var builder = toBuilderMethod.Invoke(dict, null) as IDictionary;
                builder[key] = value;
                var toImmutableMethod = builder.GetType().GetMethod(nameof(ImmutableDictionary<string, object>.Builder.ToImmutable));
                return toImmutableMethod.Invoke(builder, null) as IDictionary;
            }
            else
            {
                dict[key] = value;
                return dict;
            }
        }

        // Assume expression.Length > 0
        static bool TryParseValueIndexer(string expression, out string propertyName, out int index)
        {
            if (expression[expression.Length - 1] == ']')
            {
                var match = FValueIndexerRegex.Match(expression);
                if (match.Success)
                {
                    propertyName = match.Groups[1].Value;
                    if (int.TryParse(match.Groups[2].Value, out index))
                        return true;
                }
            }
            propertyName = expression;
            index = -1;
            return false;
        }

        // Assume expression.Length > 0
        static bool TryParseStringIndexer(string expression, out string propertyName, out string key)
        {
            if (expression[expression.Length - 1] == ']')
            {
                var match = FStringIndexerRegex.Match(expression);
                if (match.Success)
                {
                    propertyName = match.Groups[1].Value;
                    key = match.Groups[2].Value;
                    return true;
                }
            }
            propertyName = expression;
            key = null;
            return false;
        }
    }
}
