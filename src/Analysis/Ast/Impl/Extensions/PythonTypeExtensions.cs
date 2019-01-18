﻿// Copyright(c) Microsoft Corporation
// All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the License); you may not use
// this file except in compliance with the License. You may obtain a copy of the
// License at http://www.apache.org/licenses/LICENSE-2.0
//
// THIS CODE IS PROVIDED ON AN  *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS
// OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY
// IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABILITY OR NON-INFRINGEMENT.
//
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.

using Microsoft.Python.Analysis.Specializations.Typing;
using Microsoft.Python.Analysis.Types;

namespace Microsoft.Python.Analysis {
    public static class PythonTypeExtensions {
        public static bool IsUnknown(this IPythonType value) =>
            value == null || (value.TypeId == BuiltinTypeId.Unknown && value.MemberType == PythonMemberType.Unknown && value.Name.Equals("Unknown"));

        public static bool IsGenericParameter(this IPythonType value) 
            => value is IGenericTypeParameter;

        public static void TransferDocumentation(this IPythonType src, IPythonType dst) {
            if (src != null && dst is PythonType pt) {
                pt.TrySetTypeId(dst.TypeId);
                var documentation = src.Documentation;
                if (!string.IsNullOrEmpty(documentation)) {
                    pt.SetDocumentationProvider(_ => documentation);
                }
            }
        }
    }
}