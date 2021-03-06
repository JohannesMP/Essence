﻿using System;

/*
 * Licensed to the Apache Software Foundation (ASF) under one or more
 * contributor license agreements.  See the NOTICE file distributed with
 * this work for additional information regarding copyright ownership.
 * The ASF licenses this file to You under the Apache License, Version 2.0
 * (the "License"); you may not use this file except in compliance with
 * the License.  You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

namespace org.apache.commons.math3.analysis
{
    /// <summary>
    /// Extension of <seealso cref="UnivariateFunction"/> representing a differentiable univariate real function.
    /// 
    /// @version $Id: DifferentiableUnivariateFunction.java 1383845 2012-09-12 08:34:10Z luc $ </summary>
    /// @deprecated as of 3.1 replaced by <seealso cref="org.apache.commons.math3.analysis.differentiation.UnivariateDifferentiableFunction"/> 
    //[Obsolete("as of 3.1 replaced by <seealso cref="org.apache.commons.math3.analysis.differentiation.UnivariateDifferentiableFunction"/>")]
    public interface DifferentiableUnivariateFunction : UnivariateFunction
    {
        /// <summary>
        /// Returns the derivative of the function
        /// </summary>
        /// <returns>  the derivative function </returns>
        UnivariateFunction Derivative();
    }

    public class DelegateDifferentiableUnivariateFunction : DelegateUnivariateFunction, DifferentiableUnivariateFunction
    {
        public DelegateDifferentiableUnivariateFunction(Func<double, double> func, Func<double, double> dfunc)
            : base(func)
        {
            this.dfunc = dfunc;
        }

        private readonly Func<double, double> dfunc;

        public UnivariateFunction Derivative()
        {
            return new DelegateUnivariateFunction(this.dfunc);
        }
    }
}