namespace ExceptionSandbox;

public class EasyCalculator
{
    private ILogger logger;
    //Constructor injection
    public EasyCalculator(ILogger logger)
    {
        this.logger = logger;
    }
    public int? Calc(string inp)
    {
        try
        {

            string[] parts = inp.Split();
            //0 is first num
            //1 is operand
            //2 is second num
            if (parts.Length < 3)
                throw new FormatException("The input should consist of 3 parts divided by spaces");

            int a;
            int b;

            if (!int.TryParse(parts[0], out a))
                throw new InputException("The input must be a value, the first input is incorrect");
            if (!int.TryParse(parts[2], out b))
                throw new InputException("The input must be a value, the second input is incorrect");

            string operatorStr = parts[1];
            if (operatorStr.Length > 1)
                throw new FormatException("The operator should not be longer than 1 character");

            int result = 0;
            switch (parts[1][0])
            {
                case '+':
                    result = a + b;
                    break;
                case '-':
                    result = a - b;
                    break;
                case '*':
                    result = a * b;
                    break;
                case '/':
                    if (b == 0)
                        throw new DivideByZeroException("The denominator cannot be zero");
                    result = a / b;
                    break;
                default:
                    throw new InputException("The operator can only be one of : + - * /");
            }

            return result;
        }
        catch (Exception e)
        {
            logger.Log(e);
            Console.WriteLine(e.Message);
        }

        return null;
    }
}