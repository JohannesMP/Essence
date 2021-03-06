﻿// Copyright 2017 Jose Luis Rovira Martin
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.IO;

namespace Essence.Util.IO
{
    public static class IOUtils
    {
        /// <summary>
        ///     Copia el stream <c>input</c> en el stream <c>output</c>.
        /// </summary>
        /// <param name="input">Stream de entrada.</param>
        /// <param name="output">Stream de salida.</param>
        public static void Copy(Stream input, Stream output, int buffSize = 8 * 1024)
        {
            byte[] buffer = new byte[buffSize];
            int len;
            while ((len = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, len);
            }
        }
    }
}