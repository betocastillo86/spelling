//-----------------------------------------------------------------------
// <copyright file="EmbeddedImage.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Mobile.MarkupExtensions
{
    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// Embedded Image
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Xaml.IMarkupExtension" />
    [ContentProperty("ResourceId")]
    public class EmbeddedImage : IMarkupExtension
    {
        /// <summary>
        /// Gets or sets the resource identifier.
        /// </summary>
        /// <value>
        /// The resource identifier.
        /// </value>
        public string ResourceId { get; set; }

        /// <summary>
        /// Returns the object created from the markup extension.
        /// </summary>
        /// <param name="serviceProvider">The service that provides the value.</param>
        /// <returns>
        /// The object
        /// </returns>
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrEmpty(this.ResourceId))
            {
                return null;
            }

            return ImageSource.FromResource(this.ResourceId);
        }
    }
}