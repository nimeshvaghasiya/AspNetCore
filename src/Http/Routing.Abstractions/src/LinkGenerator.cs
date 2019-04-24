// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Routing
{
    /// <summary>
    /// Defines a contract to generate absolute and related URIs based on endpoint routing.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Generating URIs in endpoint routing occurs in two phases. First, an address is bound to a list of
    /// endpoints that match the address. Secondly, each endpoint's <c>RoutePattern</c> is evaluated, until 
    /// a route pattern that matches the supplied values is found. The resulting output is combined with
    /// the other URI parts supplied to the link generator and returned.
    /// </para>
    /// <para>
    /// The methods provided by the <see cref="LinkGenerator"/> type are general infrastructure, and support
    /// the standard link generator functionality for any type of address. The most convenient way to use 
    /// <see cref="LinkGenerator"/> is through extension methods that perform operations for a specific
    /// address type.
    /// </para>
    /// </remarks>
    public abstract class LinkGenerator
    {
        /// <summary>
        /// Generates a URI with an absolute path based on the provided values and <see cref="HttpContext"/>.
        /// </summary>
        /// <typeparam name="TAddress">The address type.</typeparam>
        /// <param name="httpContext">The <see cref="HttpContext"/> associated with the current request.</param>
        /// <param name="address">The address value. Used to resolve endpoints.</param>
        /// <param name="values">The route values. Used to expand parameters in the route template. Optional.</param>
        /// <param name="ambientValues">The values associated with the current request. Optional.</param>
        /// <param name="pathBase">
        /// An optional URI path base. Prepended to the path in the resulting URI. If not provided, the value of <see cref="HttpRequest.PathBase"/> will be used.
        /// </param>
        /// <param name="fragment">An optional URI fragment. Appended to the resulting URI.</param>
        /// <param name="options">
        /// An optional <see cref="LinkOptions"/>. Settings on provided object override the settings with matching
        /// names from <c>RouteOptions</c>.
        /// </param>
        /// <returns>A URI with an absolute path, or <c>null</c>.</returns>
        public abstract string GetPathByAddress<TAddress>(
            HttpContext httpContext,
            TAddress address,
            RouteValueDictionary values,
            RouteValueDictionary ambientValues = default,
            PathString? pathBase = default,
            FragmentString fragment = default,
            LinkOptions options = default);

        /// <summary>
        /// Generates a URI with an absolute path based on the provided values.
        /// </summary>
        /// <typeparam name="TAddress">The address type.</typeparam>
        /// <param name="address">The address value. Used to resolve endpoints.</param>
        /// <param name="values">The route values. Used to expand parameters in the route template. Optional.</param>
        /// <param name="pathBase">An optional URI path base. Prepended to the path in the resulting URI.</param>
        /// <param name="fragment">An optional URI fragment. Appended to the resulting URI.</param>
        /// <param name="options">
        /// An optional <see cref="LinkOptions"/>. Settings on provided object override the settings with matching
        /// names from <c>RouteOptions</c>.
        /// </param>
        /// <returns>A URI with an absolute path, or <c>null</c>.</returns>
        public abstract string GetPathByAddress<TAddress>(
            TAddress address,
            RouteValueDictionary values,
            PathString pathBase = default,
            FragmentString fragment = default,
            LinkOptions options = default);

        /// <summary>
        /// Generates an absolute URI based on the provided values and <see cref="HttpContext"/>.
        /// </summary>
        /// <typeparam name="TAddress">The address type.</typeparam>
        /// <param name="httpContext">The <see cref="HttpContext"/> associated with the current request.</param>
        /// <param name="address">The address value. Used to resolve endpoints.</param>
        /// <param name="values">The route values. Used to expand parameters in the route template. Optional.</param>
        /// <param name="ambientValues">The values associated with the current request. Optional.</param>
        /// <param name="scheme">
        /// The URI scheme, applied to the resulting URI. Optional. If not provided, the value of <see cref="HttpRequest.Scheme"/> will be used.
        /// </param>
        /// <param name="host">
        /// The URI host/authority, applied to the resulting URI. Optional. If not provided, the value <see cref="HttpRequest.Host"/> will be used.
        /// See the remarks section for details about the security implications of the <paramref name="host"/>.
        /// </param>
        /// <param name="pathBase">
        /// An optional URI path base. Prepended to the path in the resulting URI. If not provided, the value of <see cref="HttpRequest.PathBase"/> will be used.
        /// </param>
        /// <param name="fragment">An optional URI fragment. Appended to the resulting URI.</param>
        /// <param name="options">
        /// An optional <see cref="LinkOptions"/>. Settings on provided object override the settings with matching
        /// names from <c>RouteOptions</c>.
        /// </param>
        /// <returns>A URI with an absolute path, or <c>null</c>.</returns>
        /// <remarks>
        /// <para>
        /// The value of <paramref name="host" /> should be a trusted value. Relying on the value of the current request
        /// can allow untrusted input to influence the resulting URI unless the <c>Host</c> header has been validated.
        /// See the deployment documentation for instructions on how to properly validate the <c>Host</c> header in
        /// your deployment environment.
        /// </para>
        /// </remarks>
        public abstract string GetUriByAddress<TAddress>(
            HttpContext httpContext,
            TAddress address,
            RouteValueDictionary values,
            RouteValueDictionary ambientValues = default,
            string scheme = default,
            HostString? host = default,
            PathString? pathBase = default,
            FragmentString fragment = default,
            LinkOptions options = default);

        /// <summary>
        /// Generates an absolute URI based on the provided values.
        /// </summary>
        /// <typeparam name="TAddress">The address type.</typeparam>
        /// <param name="address">The address value. Used to resolve endpoints.</param>
        /// <param name="values">The route values. Used to expand parameters in the route template. Optional.</param>
        /// <param name="scheme">The URI scheme, applied to the resulting URI.</param>
        /// <param name="host">
        /// The URI host/authority, applied to the resulting URI.
        /// See the remarks section for details about the security implications of the <paramref name="host"/>.
        /// </param>
        /// <param name="pathBase">An optional URI path base. Prepended to the path in the resulting URI.</param>
        /// <param name="fragment">An optional URI fragment. Appended to the resulting URI.</param>
        /// <param name="options">
        /// An optional <see cref="LinkOptions"/>. Settings on provided object override the settings with matching
        /// names from <c>RouteOptions</c>.
        /// </param>
        /// <returns>An absolute URI, or <c>null</c>.</returns>
        /// <remarks>
        /// <para>
        /// The value of <paramref name="host" /> should be a trusted value. Relying on the value of the current request
        /// can allow untrusted input to influence the resulting URI unless the <c>Host</c> header has been validated.
        /// See the deployment documentation for instructions on how to properly validate the <c>Host</c> header in
        /// your deployment environment.
        /// </para>
        /// </remarks>
        public abstract string GetUriByAddress<TAddress>(
            TAddress address,
            RouteValueDictionary values,
            string scheme,
            HostString host,
            PathString pathBase = default,
            FragmentString fragment = default,
            LinkOptions options = default);

        /// <summary>
        /// Attempts to pass the provided <paramref name="path"/> using the route pattern
        /// specified by the <see cref="Endpoint"/> matching <paramref name="address"/>.
        /// </summary>
        /// <typeparam name="TAddress">The address type.</typeparam>
        /// <param name="address">The address value. Used to resolve endpoints.</param>
        /// <param name="path">The URI path to parse.</param>
        /// <returns>
        /// A <see cref="RouteValueDictionary"/> with the parsed values if parsing is successful; 
        /// otherwise <c>null</c>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="ParsePathByAddress{TAddress}(TAddress, PathString)"/> will attempt to first resolve
        /// <see cref="Endpoint"/> instances that match <paramref name="address"/> and then use the route
        /// pattern associated with each endpoint to parse the URL path. 
        /// </para>
        /// <para>
        /// The parsing operation will fail and return <c>null</c> if either no endpoints are found or none
        /// of the route patterns match the provided URI path.
        /// </para>
        /// </remarks>
        public virtual RouteValueDictionary ParsePathByAddress<TAddress>(TAddress address, PathString path)
        {
            throw new NotImplementedException();
        }
    }
}
