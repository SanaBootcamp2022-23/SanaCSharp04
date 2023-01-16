int n, m, cntnatural = 0; bool isFound = false;   
Console.WriteLine("Enter rows\nN =");
n = int.Parse(Console.ReadLine());
Console.WriteLine("Enter columns\nM =");
m = int.Parse(Console.ReadLine());

Random randel = new Random();
int[,] matrix = new int[n, m];
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        matrix[i, j] = randel.Next(-5, 6);
        Console.Write("{0,5}", matrix[i, j]);
    }
    Console.WriteLine();
}
for (int i = 0; i < n; i++)
    for (int j = 0; j < m; j++)
        if (matrix[i, j] > 0)
            cntnatural++;
Console.WriteLine("Count of natural numbers: " + cntnatural);
int[] temp = new int[m*n]; int k = 0;
for (int i = 0; i < n; i++)
    for (int j = 0; j < m; j++)
    {
        temp[k] = matrix[i, j];
        k++;
    }

int maxel = int.MinValue; int count = 0; int imax = 0;
for (int i = 0; i < k; i++)
{
    for (int j = 0; j < k; j++)
    {
        if (temp[j] > maxel)
        {
            maxel = temp[j];
            imax = j;
        }
    }
    for (int j = 0; j < k; j++)
    {
        if (temp[j] == maxel)
        {
            count++;
        }
    }
    if(count>1)
    {
        isFound = true;
        break;
    }
    else
    {
        for(int j = imax; j< k-1;j++)
        {
                temp[j] = temp[j + 1];                     
        }
        k--;
    }
    count = 0;
    maxel = int.MinValue;
}
if(isFound == true)
    Console.WriteLine("Max dublicated  num: " + maxel);
else
    Console.WriteLine("Any numbers of the array does not duplicate");

bool isZero = false; 
count = 0;
for(int i = 0;i<n;i++)
{
    for(int j = 0; j < m; j++)
    {
        if (matrix[i,j] == 0)
        {
            isZero = true;
            break;
        }
        isZero = false;
    }
    if (isZero == false)
        count++;
}
Console.WriteLine("Amount of rows without zeros: " + count);
isZero = false; count = 0;
for (int i = 0; i < m; i++)
{
    for (int j = 0; j < n; j++)
    {
        if (matrix[j, i] == 0)
        {
            isZero = true;
            break;
        }
        isZero = false;
    }
    if (isZero == true)
        count++;
}

Console.WriteLine("Amount of columns with zeros: " + count);
count = 0; int maxseries = 0; imax = 0; isFound = false;
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m-1; j++)
    {
        if (matrix[i, j] == matrix[i, j+1])
            count++;
    }
    if (count > maxseries)
    {
        isFound = true;
        maxseries = count;
        imax = i;
    }
    count = 0;
}
if(isFound == true)
    Console.WriteLine("Row number with the longest series of same numbers: " + (imax + 1));
else
    Console.WriteLine("Series of numbers not found");

Console.WriteLine("Product of rows elements without negative numbers: ");
bool isBelowZero = false; int res = 1;
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        if (matrix[i, j] < 0)
        {
            isBelowZero = true;
            break;
        }
    }
    if(isBelowZero == false)
    {
        for (int j = 0; j < m; j++)
        {
            res *= matrix[i, j];
        }
        Console.WriteLine($"Row #{i + 1} product: " + res);
        res = 1;
    }
    isBelowZero = false;
}
res = 0; maxel = int.MinValue;
for(int i = n-1;i>0;i--)
{
    int j = 0;
    int l = i;
    do
    {
        res += matrix[l, j];
        j++;
        l++;
    } while (l < n && j < m);
    if (res > maxel)
        maxel = res;
    res = 0;
}

for (int i = m - 1; i > 0; i--) 
{
    int j = 0;
    int l = i;
    do
    {
        res += matrix[j, l];
        l++;
        j++;
    } while (l<m && j<n);
    if (res > maxel)
        maxel = res;
    res = 0;
}
Console.WriteLine("Max diagonal sum parallel to the main diagonal: " + maxel);

Console.WriteLine("Columns sum without negative numbers:");
res = 0;
isBelowZero = false;
for (int i = 0; i < m; i++)
{
    for (int j = 0; j < n; j++)
    {
        if (matrix[j,i] < 0)
        {
            isBelowZero = true;
            break;
        }
    }
    if(isBelowZero == false)
    {
        for (int j = 0; j < n; j++)
        {
            res += matrix[j, i];
        }
        Console.WriteLine($"Column #{i + 1} sum: " + res);
        res = 0;
    }
    isBelowZero = false;
}

int minel = int.MaxValue;
for (int i = 0; i < n-1; i++)
{
    int j = 0;
    int l = i;
    do
    {
        res += Math.Abs(matrix[l, j]); 
        l--;
        j++;
    } while (l >= 0 && j < m);
    if (Math.Abs(res) < minel)
        minel = Math.Abs(res); ;
    res = 0;
}

for (int i = m - 1; i > 0; i--)
{
    int l = i;
    int j = n - 1;
    do
    {
        res += Math.Abs(matrix[j, l]);
        l++;
        j--;
    } while (l < m && j>=0);
    if (Math.Abs(res) < minel)
        minel = Math.Abs(res);
    res = 0;
}
Console.WriteLine("Minimal module of sum elemnts of diagonals parallel to the side diagonal: " + minel);
Console.WriteLine("Columns sum with negative numbers:");
res = 0;
isBelowZero = false;
for (int i = 0; i < m; i++)
{
    for (int j = 0; j < n; j++)
    {
        if (matrix[j, i] < 0)
        {
            isBelowZero = true;
            break;
        }
    }
    if (isBelowZero == true)
    {
        for (int j = 0; j < n; j++)
        {
            res += matrix[j, i];
        }
        Console.WriteLine($"Column #{i + 1} sum: " + res);
        res = 0;
    }
    isBelowZero = false;
}
int[,] tmatrix = new int[m, n];
Console.WriteLine("Transposed matrix:");
for (int i = 0; i < m; i++)
{
    for (int j = 0; j < n; j++)
    {
        tmatrix[i, j] = matrix[j, i];
        Console.Write("{0,5}", tmatrix[i, j]);
    }
    Console.WriteLine();
}