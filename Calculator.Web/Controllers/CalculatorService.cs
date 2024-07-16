using Calculator.Common.Dto;
using Calculator.Common.Dto;

namespace Calculator.Business
{
    public class CalculatorService
    {
        public Result Add(AddDto1 addDto)
        {
            return new Result
            {
                Value = addDto.Number1 + addDto.Number2   //Toplama İşlemi fonksiyonu
            };
        }

        public Result Subtract(AddDto1 addDto)
        {
            return new Result
            {
                Value = addDto.Number1 - addDto.Number2  //Çıkartma
            };
        }

        public Result Multiply(AddDto1 addDto)
        {
            return new Result
            {
                Value = addDto.Number1 * addDto.Number2  //Çarpma
            };
        }

        public Result Divide(AddDto1 addDto)
        {
            if (addDto.Number2 == 0)
            {
                throw new DivideByZeroException("Number2 cannot be zero.");  //Bölme işlemi ayrıca 2.sayı 0 olamaz
            }

            return new Result
            {
                Value = addDto.Number1 / addDto.Number2
            };
        }
    }
}