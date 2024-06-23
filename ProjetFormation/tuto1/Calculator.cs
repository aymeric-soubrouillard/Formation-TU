namespace ProjetFormation.tuto1
{
    public class Calculator
    {
        public int Divide(int numerator, int denominator){
            if(denominator == 0){
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return numerator/denominator;
        }
    }
}