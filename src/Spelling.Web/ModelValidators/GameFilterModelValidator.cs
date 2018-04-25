//-----------------------------------------------------------------------
// <copyright file="GameFilterModelValidator.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Web.ModelValidators
{
    using Beto.Core.Web.Api.Models;
    using FluentValidation;
    using Spelling.Models;

    /// <summary>
    /// Game Filter Model Validator
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{Spelling.Models.GameFilterModel}" />
    public class GameFilterModelValidator : AbstractValidator<GameFilterModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameFilterModelValidator"/> class.
        /// </summary>
        public GameFilterModelValidator()
        {
            this.AddBaseFilterValidations();

            this.RuleFor(c => c.UserId)
                .NotNull();
        }
    }
}