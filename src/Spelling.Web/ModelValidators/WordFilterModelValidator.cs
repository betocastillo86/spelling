//-----------------------------------------------------------------------
// <copyright file="WordFilterModelValidator.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Web.ModelValidators
{
    using Beto.Core.Web.Api.Models;
    using FluentValidation;
    using Spelling.Models;

    /// <summary>
    /// Word Filter Model Validator
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{Spelling.Models.WordFilterModel}" />
    public class WordFilterModelValidator : AbstractValidator<WordFilterModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WordFilterModelValidator"/> class.
        /// </summary>
        public WordFilterModelValidator()
        {
            this.AddBaseFilterValidations();
        }
    }
}