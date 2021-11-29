
string veelwerf(string tekst, int aantal)
{

	string output = "";
	int x = 0;
	while (x < aantal)
	{

		output = output + tekst;
		x++;
	}
	return output;
}

int machtsverheffing(int grondtal, int exponent)
{
	int x = 0;
	int result = 1;
	while (x < exponent)
    {
		result = result * grondtal;
		x++;
		
	}
	return result;
}


bool deelbaar(int x, int d)
{

	return x % d == 0;
}

int kleinsteDeler(int input)
{
	int x = 2;
	int output;
	while (input % x != 0)
	{
		x++;
	}
	return x;
}

Console.WriteLine(deelbaar(10,3));
Console.WriteLine(kleinsteDeler(51));
