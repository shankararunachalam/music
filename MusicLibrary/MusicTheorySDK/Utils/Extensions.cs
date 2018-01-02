using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace MusicTheorySDK.Utils
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Circle<T>(this IEnumerable<T> list, int startIndex)
        {
            var localList = list.ToList();
            return localList.GetRange(startIndex, localList.Count - startIndex)
                            .Concat(localList.GetRange(0, startIndex));
        }
    }

    class PositionAttribute : Attribute
    {
        internal PositionAttribute(int position)
        {
            this.Position = position;
        }
        public int Position { get; private set; }
    }

    class NoteOfAttribute : Attribute
    {
        internal NoteOfAttribute(char noteOf)
        {
            this.NoteOf = noteOf;
        }
        public char NoteOf { get; private set; }
    }

    public static class EnumExtensions
    {
        public static string GetDescription<T>(this T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }
    }

    public static class NotesExtensions
    {
        public static int GetPosition<T>(this T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            PositionAttribute[] attributes = (PositionAttribute[])fi.GetCustomAttributes(
                typeof(PositionAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Position;
            else return 0;
        }

        public static char GetNoteOf<T>(this T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            NoteOfAttribute[] attributes = (NoteOfAttribute[])fi.GetCustomAttributes(
                typeof(NoteOfAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].NoteOf;
            else return 'C';
        }
    }
}
