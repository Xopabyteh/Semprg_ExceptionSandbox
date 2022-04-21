using ExceptionSandbox;

const string PATH = "errors.txt";
EasyCalculator calculator = new EasyCalculator(new FileExceptionLogger(PATH));

calculator.Calc("1 / 0");
calculator.Calc($"{int.MaxValue} + 1");
calculator.Calc("");
calculator.Calc("1+1");
calculator.Calc("");
calculator.Calc("1 + a");

