#include <fstream>
#include <iostream>
#include "MatriceRara.h"
using namespace std;


int main()
{
	MatriceRara mr;
	mr.loadSample();
	mr.rezolva();
	return 0;
}