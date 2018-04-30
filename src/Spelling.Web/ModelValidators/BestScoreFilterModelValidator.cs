//-----------------------------------------------------------------------
// <copyright file="BestScoreFilterModelValidator.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Web.ModelValidators
{
    using Beto.Core.Web.Api.Models;
    using FluentValidation;
    using Spelling.Models;

    /// <summary>
    /// Best Score Filter Validator
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{Spelling.Models.BestScoreFilterModel}" />
    public class BestScoreFilterModelValidator : AbstractValidator<BestScoreFilterModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BestScoreFilterModelValidator"/> class.
        /// </summary>
        public BestScoreFilterModelValidator()
        {
            this.AddBaseFilterValidations();

            this.RuleFor(c => c.GroupType)
                .NotNull();
        }
    }
}