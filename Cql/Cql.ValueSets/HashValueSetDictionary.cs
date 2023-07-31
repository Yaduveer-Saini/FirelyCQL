﻿/* 
 * Copyright (c) 2023, NCQA and contributors
 * See the file CONTRIBUTORS for details.
 * 
 * This file is licensed under the BSD 3-Clause license
 * available at https://raw.githubusercontent.com/FirelyTeam/cql-sdk/main/LICENSE
 */

using Hl7.Cql.Comparers;
using Hl7.Cql.Primitives;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Hl7.Cql.ValueSets
{
    /// <summary>
    /// Uses hash sets to identify code membership within value sets.
    /// </summary>
    public class HashValueSetDictionary : IValueSetDictionary
    {
        // Table with unique CqlCodes, so having many valuesets with identical codes will
        // not result in duplicate codes. Also helps with comparing codes by reference for speed.

        private readonly ConcurrentDictionary<CqlCode, CqlCode> _internHash;

        public CqlCode Intern(CqlCode code) => _internHash.GetOrAdd(code, code);

        public HashValueSetDictionary(ICqlComparer<CqlCode> comparer)
        {
            _comparer = comparer;
            _internHash = new(_comparer.ToEqualityComparer());
        }

        public HashValueSetDictionary() : this(new CqlCodeCqlComparer())
        {
            // nothing
        }

        /// <summary>
        /// Adds the code to the given value set by its canonical URI.
        /// </summary>
        /// <param name="valueSetUri">The value set's canonical URI.</param>
        /// <param name="code">The code to add.</param>
        public void Add(string valueSetUri, CqlCode code)
        {
            if (string.IsNullOrEmpty(valueSetUri)) throw new ArgumentException($"'{nameof(valueSetUri)}' cannot be null or empty.", nameof(valueSetUri));
            if (code is null) throw new ArgumentNullException(nameof(code));

            code = Intern(code);
            if (!_codesInValueSet.TryGetValue(valueSetUri, out var codes))
            {
                codes = new InMemoryValueSet(new[] { code }, _comparer);
                _codesInValueSet.Add(valueSetUri, codes);
            }
            else
            {
                if (codes is InMemoryValueSet imvs)
                    imvs.Add(code);
                else
                    throw new NotSupportedException($"Valueset {valueSetUri} is read-only and cannot be added to.");
            }
        }

        /// <summary>
        /// Adds the code to the given value set by its canonical URI.
        /// </summary>
        /// <param name="valueSetUri">The value set's canonical URI.</param>
        /// <param name="codes">The codes to add.</param>
        /// <exception cref="ArgumentException">If the valueset already exists in the dictionary.</exception>
        public void Add(string valueSetUri, IEnumerable<CqlCode> codes)
        {
            if (_codesInValueSet.ContainsKey(valueSetUri))
                throw new ArgumentException($"Valueset {valueSetUri} already exists in dictionary.");

            var internedCodes = codes.Select(Intern);
            _codesInValueSet.Add(valueSetUri, new InMemoryValueSet(internedCodes));
        }

        /// <inheritdoc/>
        public bool IsCodeInValueSet(string valueSetUri, string code) =>
             _codesInValueSet.TryGetValue(valueSetUri, out var vs) && vs.IsCodeInValueSet(code);

        /// <inheritdoc/>
        public bool IsCodeInValueSet(string valueSetUri, string code, string? systemUriOrOid) =>
            _codesInValueSet.TryGetValue(valueSetUri, out var vs) && vs.IsCodeInValueSet(code, systemUriOrOid);

        /// <inheritdoc/>
        public bool IsCodeInValueSet(string valueSetUri, CqlCode code) =>
            _codesInValueSet.TryGetValue(valueSetUri, out var vs) && vs.IsCodeInValueSet(code);

        /// <summary>
        /// Tries to ge the codes in the value set as an <see cref="IReadOnlyCollection{CqlCode}"/>.
        /// </summary>
        /// <param name="valueSetUri">The value set's canonical URI.</param>
        /// <param name="codes">The <see langword="out"/> parameter for the value set's codes, or <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if the given value set is defined; otherwise, <see langword="false"/>.</returns>
        public bool TryGetCodesInValueSet(string valueSetUri, out IEnumerable<CqlCode>? codes)
        {
            if (_codesInValueSet.TryGetValue(valueSetUri, out var codeSet))
            {
                codes = codeSet;
                return true;
            }
            codes = null!;
            return false;
        }

        public bool HasValueSet(string valueSetUri) => _codesInValueSet.ContainsKey(valueSetUri);


        private readonly Dictionary<string, IValueSetFacade> _codesInValueSet = new(StringComparer.OrdinalIgnoreCase);
        private readonly ICqlComparer<CqlCode> _comparer;
    }
}
