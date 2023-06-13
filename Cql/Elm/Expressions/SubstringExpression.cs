﻿/* 
 * Copyright (c) 2023, NCQA and contributors
 * See the file CONTRIBUTORS for details.
 * 
 * This file is licensed under the BSD 3-Clause license
 * available at https://raw.githubusercontent.com/FirelyTeam/cql-sdk/main/LICENSE
 */

namespace Hl7.Cql.Elm.Expressions
{
    public class SubstringExpression : Expression
    {
        public Expression? stringToSub { get; set; }

        public Expression? startIndex { get; set; }

        public Expression? length { get; set; }

    }
}
