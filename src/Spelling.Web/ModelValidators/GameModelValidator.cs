//-----------------------------------------------------------------------
// <copyright file="GameModelValidator.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Web.ModelValidators
{
    using FluentValidation;
    using Spelling.Models;

    /// <summary>
    /// Game Model Validator
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{Spelling.Models.GameModel}" />
    public class GameModelValidator : AbstractValidator<GameModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameModelValidator"/> class.
        /// </summary>
        public GameModelValidator()
        {
            this.RuleFor(c => c.GroupType)
                .NotNull();

            this.RuleFor(c => c.OriginLanguage)
                .NotNull();
        }
    }
}