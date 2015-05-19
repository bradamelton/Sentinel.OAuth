﻿namespace Sentinel.OAuth.TokenManagers.RedisTokenRepository.Implementation
{
    using System;
    using System.Text;

    using Sentinel.OAuth.Core.Interfaces.Factories;
    using Sentinel.OAuth.Core.Interfaces.Models;
    using Sentinel.OAuth.TokenManagers.RedisTokenRepository.Models;

    /// <summary>A token factory for Redis entities.</summary>
    public class RedisTokenFactory : ITokenFactory
    {
        /// <summary>Creates an access token.</summary>
        /// <param name="clientId">The client identifier.</param>
        /// <param name="redirectUri">The redirect URI.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="token">The hashed token.</param>
        /// <param name="ticket">The encrypted principal.</param>
        /// <param name="validTo">The point in time where the token expires.</param>
        /// <returns>The new access token.</returns>
        public IAccessToken CreateAccessToken(
            string clientId,
            string redirectUri,
            string userId,
            string token,
            string ticket,
            DateTime validTo)
        {
            return new RedisAccessToken()
                       {
                           Id = Convert.ToBase64String(Encoding.UTF8.GetBytes(clientId + redirectUri + userId + validTo.ToString("O"))),
                           ClientId = clientId,
                           RedirectUri = redirectUri,
                           Subject = userId,
                           Token = token,
                           Ticket = ticket,
                           ValidTo = validTo,
                           Created = DateTime.UtcNow
                       };
        }

        /// <summary>Creates a refresh token.</summary>
        /// <param name="clientId">The client identifier.</param>
        /// <param name="redirectUri">The redirect URI.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="token">The hashed token.</param>
        /// <param name="validTo">The point in time where the token expires.</param>
        /// <returns>The new refresh token.</returns>
        public IRefreshToken CreateRefreshToken(string clientId, string redirectUri, string userId, string token, DateTime validTo)
        {
            return new RedisRefreshToken()
                       {
                           Id = Convert.ToBase64String(Encoding.UTF8.GetBytes(clientId + redirectUri + userId + validTo.Ticks)),
                           ClientId = clientId,
                           RedirectUri = redirectUri,
                           Subject = userId,
                           Token = token,
                           ValidTo = validTo
                       };
        }

        /// <summary>Creates an authorization code.</summary>
        /// <param name="clientId">The client identifier.</param>
        /// <param name="redirectUri">The redirect URI.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="scope">The scope.</param>
        /// <param name="code">The hashed code.</param>
        /// <param name="ticket">The encrypted principal.</param>
        /// <param name="validTo">The point in time where the code expires.</param>
        /// <returns>The new authorization code.</returns>
        public IAuthorizationCode CreateAuthorizationCode(
            string clientId,
            string redirectUri,
            string userId,
            string[] scope,
            string code,
            string ticket,
            DateTime validTo)
        {
            return new RedisAuthorizationCode()
                       {
                           Id = Convert.ToBase64String(Encoding.UTF8.GetBytes(clientId + redirectUri + userId + validTo.Ticks)),
                           ClientId = clientId,
                           RedirectUri = redirectUri,
                           Subject = userId,
                           Scope = scope,
                           Code = code,
                           Ticket = ticket,
                           ValidTo = validTo,
                           Created = DateTime.UtcNow
                       };
        }
    }
}