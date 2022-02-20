namespace BackendTestWork.Helpers
{
    public class Exercises
    {
        public int RunFactorial(int n)
        {
            if (n == 0)
                n = 1;
            else
                n *= RunFactorial(n - 1);

            return n;
        }
        public int RunPotencia(int x, int y)
        {
            int result;
            switch (y)
            {
                case 0:
                    result = 1;
                    break;
                case 1:
                    result = x;
                    break;
                default:
                    result = x * this.RunPotencia(x, y - 1);
                break;
            }
            return result;
        }
    }
}
