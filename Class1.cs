namespace LabsAlgotims
{
    class Class1
    {
        //Алгоритм машины тьюринга
        public static int LABS2(int y, int x)
        {
            if (y <= x)
            {
                return x ^ 2 + y ^ 2;
            }
            if (y > x)
            {
                return y / x;
            }
            else
            {
                return 0;
            }
        }
    }
}
