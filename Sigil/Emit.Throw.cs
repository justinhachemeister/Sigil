﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

using Sigil.Impl;

namespace Sigil
{
    public partial class Emit<DelegateType>
    {
        public void Throw()
        {
            var onStack = Stack.Top();

            if (onStack == null)
            {
                throw new SigilException("Throw expected a value on the stack, but it was empty", Stack);
            }

            var val = onStack[0];

            if (!typeof(Exception).IsAssignableFrom(val))
            {
                throw new SigilException("Throw expected an exception to be on the stack, found " + val, Stack);
            }

            UpdateState(OpCodes.Throw, pop: 1);
        }
    }
}
