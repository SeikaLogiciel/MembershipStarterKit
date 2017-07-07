using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace MvcMembership
{
    /// <summary>
    /// Enumerable to Enumerable Converter
    /// </summary>
    /// <typeparam name="TCollectionType">The type of the collection type.</typeparam>
    /// <typeparam name="TItemType">The type of the item type.</typeparam>
    /// <seealso cref="System.ComponentModel.TypeConverter" />
    public class EnumerableToEnumerableTConverter<TCollectionType, TItemType> : TypeConverter where TCollectionType : IEnumerable
    {
        /// <summary>
        /// Returns whether this converter can convert the object to the specified type, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="destinationType">A <see cref="T:System.Type" /> that represents the type you want to convert to.</param>
        /// <returns>
        ///   <see langword="true" /> if this converter can perform the conversion; otherwise, <see langword="false" />.
        /// </returns>
        public override bool CanConvertTo( ITypeDescriptorContext context, Type destinationType )
        {
            return destinationType.IsAssignableFrom(typeof(IEnumerable<TItemType>))
                    ? true
                    : base.CanConvertTo( context, destinationType );
        }

        /// <summary>
        /// Converts to.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public T ConvertTo<T>( object value )
        {
            return (T)ConvertTo( value, typeof(T) );
        }

        /// <summary>
        /// Converts the given value object to the specified type, using the specified context and culture information.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="culture">A <see cref="T:System.Globalization.CultureInfo" />. If <see langword="null" /> is passed, the current culture is assumed.</param>
        /// <param name="value">The <see cref="T:System.Object" /> to convert.</param>
        /// <param name="destinationType">The <see cref="T:System.Type" /> to convert the <paramref name="value" /> parameter to.</param>
        /// <returns>
        /// An <see cref="T:System.Object" /> that represents the converted value.
        /// </returns>
        public override object ConvertTo( ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType )
        {
            var items = (TCollectionType)value;
            var destination = new List<TItemType>();
            foreach( var item in items )
                destination.Add((TItemType)item);
            return destination;
        }
    }
}