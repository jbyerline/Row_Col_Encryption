using System;
namespace Row_Col_Encrypt
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string inputString;
            int inputStringLen;
            int sqrtoflen;
            int twoDimensionalArraySize;
            int index = 0;
            
            inputString = Console.ReadLine();

            inputStringLen = inputString.Length;

            // Take square root or string length
            sqrtoflen = (int)Math.Sqrt(inputStringLen);

            // Find the closest perfect square to the size of the input string
            if (sqrtoflen * sqrtoflen == inputStringLen)

                twoDimensionalArraySize = sqrtoflen;

            else twoDimensionalArraySize = sqrtoflen + 1;

            // Make string length a perfect square by appending "_" to the end
            for (int i = 0; i < twoDimensionalArraySize * 2; i++)
            {
                inputString += "_";
            }

            // Initialize the 1D arrays, copy string into 1D tempArr
            char[] tempArr = inputString.ToCharArray();
            char[] OneDimensionalArray = new char[twoDimensionalArraySize * twoDimensionalArraySize];

            // Initializes both 2D arrays
            char[,] initialArr = new char[twoDimensionalArraySize, twoDimensionalArraySize];
            char[,] finalArr = new char[twoDimensionalArraySize, twoDimensionalArraySize];

            // Stores 1D tempArr into the 2D initialArr
            for (int i = 0; i < twoDimensionalArraySize; i++)
            {
                for (int j = 0; j < twoDimensionalArraySize; j++)
                {
                    initialArr[i, j] = tempArr[i * twoDimensionalArraySize + j];
                    Console.WriteLine("2D Array[" + i + "][" + j + "] = " + initialArr[i, j] + "\n");
                }
            }

            // Swaps the rows and Cols of the initialArr into the finalArr
            for (int i = 0; i < twoDimensionalArraySize; i++)
            {
                for (int j = 0; j < twoDimensionalArraySize; j++)
                {
                    finalArr[i,j] = initialArr[j, i];
                    Console.WriteLine("2D Array[" + i + "][" + j + "] = " + finalArr[i, j] + "\n");
                }
            }

            // Converts the 2D finalArr back into a 1D array
            for (int y = 0; y < twoDimensionalArraySize; y++)
            {
                for (int x = 0; x < twoDimensionalArraySize; x++)
                {
                    OneDimensionalArray[index] = finalArr[y, x];
                    index++;
                }
            }

            // Concatinates the 1D array back into a string
            string answer = string.Join("", OneDimensionalArray);
            
            // Prints out encrypted string
            Console.WriteLine(answer);
        }
    }
}
