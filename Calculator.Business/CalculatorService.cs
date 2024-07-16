using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Calculator.Common.Dto;

namespace Calculator.Business
{
    public class CalculatorService
    {

        public Result Add(AddDto1 addDto)
        {
            return new Result
            {
                Value = addDto.Number1 + addDto.Number2
            };
        }

        public Result Subtract(AddDto1 addDto)
        {
            return new Result
            {
                Value = addDto.Number1 - addDto.Number2
            };
        }

        public Result Multiply(AddDto1 addDto)
        {

            return new Result
            {
                Value = addDto.Number1 * addDto.Number2
            };
        }

        public Result Divide(AddDto1 addDto)
        {
            if (addDto.Number2 == 0)
            {
                throw new DivideByZeroException("number 2 cannot be zero");
            }
            return new Result
            {
                Value = addDto.Number1 / addDto.Number2
            };
        }
    }
}
