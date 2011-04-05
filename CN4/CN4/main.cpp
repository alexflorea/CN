#include <fstream>
#include <iostream>
#include "MatriceRara.h"
using namespace std;


int main()
{
	MatriceRara mr;
	if(!mr.ReadFile("mr1.txt")) {
		printf("Diagonala are elemente egale cu 0");
		return -1;
	}

	//mr.loadSample();

	//mr.PrintAllAtributes();
	//mr.print();

	if(mr.rezolva()) {
		//mr.printX();
		printf("%.10f\n", mr.verificaSolutie());
	} else {
		printf("Solutia diverge\n");
	}
	return 0;
}