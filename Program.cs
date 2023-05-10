
internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Enter the size of the array : ");
            int raz = Convert.ToInt32(Console.ReadLine());
            double[] X = new double[raz];
            double[] Y = new double[raz];
            Console.WriteLine("Enter a value for interpolation: ");
            double x = Convert.ToDouble(Console.ReadLine());


            for (int i = 0; i < raz; i++)
            {
                Console.WriteLine($"Enter X{i + 1}: ");
                X[i] = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine($"Enter У{i + 1}: ");
                Y[i] = Convert.ToDouble(Console.ReadLine());
            }
            double res =Math.Round(GetValue(X, Y, x),3);
            Console.WriteLine($"Interpol newton X = {x}, Y = {res}");
            Console.ReadKey(true);
        }
        catch 
        {
            Console.WriteLine("Eror input");
        }

    }
    public static double GetValue(double[] X, double[] Y, double x)
    {
        double inter = Y[0];
        double t;
        List<double> ListX;
        List<double> ListY;
        for(int i = 1; i < Y.Length; i++)
        {
            ListX = new List<double>();
            ListY = new List<double>();
            t = 1;
            for(int j = 0; j<=i; j++)
            {
                ListX.Add(X[j]);
                ListY.Add(Y[j]);
                if(j<i) t *= x - X[j];
            }
            inter += SeparateDifference(ListY, ListX) * t ;
        }
        return inter;
    }
    public static double SeparateDifference(List<double> Y, List<double> X)
    {
        if(Y.Count > 2)
        {
            List<double> LeftY = new List<double>(Y);
            List<double> LeftX = new List<double>(X);
            LeftY.RemoveAt(0);
            LeftX.RemoveAt(0);
            List<double> RightY = new List<double>(Y);
            List<double> RightX = new List<double>(X);
            RightY.RemoveAt(Y.Count -1);
            RightX.RemoveAt(Y.Count - 1);
            return (SeparateDifference(LeftY, LeftX) - SeparateDifference(RightY, RightX)) / (X[X.Count - 1] - X[0]);
        }
        else if (Y.Count == 2)
        {
            return (Y[1] - Y[0]) / (X[1] - X[0]); ;
        }
        else
        {
            throw new Exception("Not available parameter");
        }
    }
}