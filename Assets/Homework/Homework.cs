using UnityEngine;
using UnityEngine.UIElements;

class Homework : MonoBehaviour
{
    void Start()
    {
        int amount = HowManyCanIBuy(10, 23, 30, 50);
        Debug.Log(amount);

        float a1 = Abs(-45);
        float min1 = Min(50, 10);
        float min2 = Min(53, 10);
        float min3 = Min(40, 10);
        float min4 = Min(50, 16);

        int n = 100;
        LogMultTable(1,10);
        LogMultTable(1, 8);
        LogMultTable(-n, n);
        Debug.Log(n);  // 100
    }

    void LogMultTable(int min, int max) 
    {
        for (int i = min; i <= max; i++)
        {
            for (int j = min; j <= max; j++)
            {
                Debug.Log(i * j);
            }
        }
        max = 0;
    }





    int HowManyCanIBuy(int fullPrice, int allMoney, float discountPercent, int creditYet)
    {
        creditYet = Clamp(creditYet, 0, 100);
        discountPercent = Clamp(discountPercent, 0, 100);

        int moneyToSpend = allMoney + (100 - creditYet);
        float priceMultiplier = 1 - (discountPercent / 100);
        float realPrice = fullPrice * priceMultiplier;

        return (int)(moneyToSpend / realPrice);
    }

    void OnValidate()
    {
        float min = Min(1, 4);
        Debug.Log(min);
    }

    float Min(float a, float b)
    {
        if (a < b)
            return a;
        else
            return b;
    }

    float Max(float a, float b)
    {
        return a > b ? a : b;
    }

    float Clamp(float value, float min, float max)
    {
        if (value > max)
            return max;

        if (value < min)
            return min;

        return value;
    }

    int Clamp(int value, int min, int max)
    {
        if (value > max)
            return max;

        if (value < min)
            return min;

        return value;
    }

    int SumOfDigits(int number)
    {
        string st = number.ToString();  // "1234"

        int sum = 0;

        for (int i = 0; i < st.Length; i++)
        {
            char c = st[i];
            int n = int.Parse(c.ToString());
            sum += n;
        }

        return sum;
    }

    int SumOfDigits2(int number)
    {
        int sum = 0;
        number = Mathf.Abs(number);

        while (number > 0)
        {
            int lastDigit = number % 10;
            sum += lastDigit;
            number = number / 10;
        }

        return sum;
    }

    int DivisibleCount(int a, int b, int max)
    {
        int count = 0;
        for (int i = 1; i <= max; i++)
        {
            if (i % a == 0 || i % b == 0)
                count++;
        }

        return count;
    }

    // --------------------------------------------

    float Abs(float number) 
    {
        if (number < 0)
            return -number;
        else
            return number;
    }


}