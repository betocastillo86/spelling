﻿//-----------------------------------------------------------------------
// <copyright file="IWorkContext.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Business.Security
{
    using Spelling.Domain;

    /// <summary>
    /// Interface of work context
    /// </summary>
    public interface IWorkContext
    {
        /// <summary>
        /// Gets the current user.
        /// </summary>
        /// <value>
        /// The current user.
        /// </value>
        User CurrentUser { get; }

        /// <summary>
        /// Gets the current user identifier.
        /// </summary>
        /// <value>
        /// The current user identifier.
        /// </value>
        int CurrentUserId { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is authenticated.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is authenticated; otherwise, <c>false</c>.
        /// </value>
        bool IsAuthenticated { get; }
    }
}