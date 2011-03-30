#include <fstream>
#include "MatriceRara.h"

using namespace std;

MatriceRara::MatriceRara()
{
	d = 0;
	val = 0;
	b = 0;
	x = 0;
	linii = 0;
	col = 0;
	n = 0;
	NN = 0;
}

void MatriceRara::ReadFile(char * t)
	{	
		char c[256]="";
		char *pch;
		d=(double*)calloc(n,sizeof(double));

		ifstream in(t);
		in.getline(c,256);
		n=atoi(c);
		in.getline(c,256);
		for(int i;i<n;i++)
		{
		in.getline(c,256);
		pch = strtok (c," ,");   
		n=atoi(pch);
		pch = strtok (NULL, " ,");
	}
}

double MatriceRara::A(int i, int j)
{
	if(i == j) {
		return d[i];
	}
	for(int k = linii[i]; k < linii[i+1]; k++) {
		if(col[k] == j) {
			return val[k];
		}
	}
	return 0;
}

double MatriceRara::sumaProdus(int i, int jMin, int jMax)
{
	if(jMin == jMax) {
		return 0;
	}
	double suma = 0;
	if(i >= jMin && i < jMax) {
		suma = d[i] * x[i];
	}
	for(int k = linii[i]; k < linii[i+1]; k++) {
		if(col[k] >= jMin && col[k] < jMax) {
			suma += val[k] * x[col[k]];
		}
	}
	return suma;
}

double MatriceRara::B(int i, int j)
{
	if(j > i) {
		return 0;
	} else {
		return A(i, j);
	}
}

void MatriceRara::loadSample()
{
	n   = 5;
	NN  = 7;
	d     = (double*)calloc(n,   sizeof(double));
	b     = (double*)calloc(n,   sizeof(double));
	val   = (double*)calloc(NN,  sizeof(double));
	col   = (int*)   calloc(NN,  sizeof(int));
	linii = (int*)   calloc(n+1, sizeof(int));

	d[0] = 102.5;
	d[1] = 104.88;
	d[2] = 100.0;
	d[3] = 101.3;
	d[4] = 102.23;

	val[0] = 2.5;
	val[1] = 1.05;
	val[2] = 3.5;
	val[3] = 0.33;
	val[4] = 1.3;
	val[5] = 0.73;
	val[6] = 1.5;

	col[0] = 2;
	col[1] = 2;
	col[2] = 0;
	col[3] = 4;
	col[4] = 1;
	col[5] = 0;
	col[6] = 3;

	linii[0] = 0;
	linii[1] = 1;
	linii[2] = 4;
	linii[3] = 4;
	linii[4] = 5;
	linii[5] = 7;

	b[0] = 6;
	b[1] = 7;
	b[2] = 8;
	b[3] = 9;
	b[4] = 1;
}

void MatriceRara::print()
{
	for(int i = 0; i < n; i++) {
		for(int j = 0; j < n; j++) {
			printf("%f ", A(i, j));
		}
		printf("\n");
	}
}

double MatriceRara::iteratie()
{
	if(!d || !val || !b || !linii || !col) {
		return 0;
	}
	if(!x) {
		x = (double*)calloc(n, sizeof(double));
		for(int i = 0; i < n; i++) {
			x[i] = 0;
		}
		printX();
	}

	double deltaX = 0;
	for(int i = 0; i < n; i++) {
		double oldXI = x[i];
		//double suma1 = 0;
		//for(int j = 0; j < i; j++) {
		//	suma1 += A(i, j) * x[j];
		//}
		//double suma2 = 0;
		//for(int j = i+1; j < n; j++) {
		//	suma2 += A(i, j) * x[j];
		//}
		//x[i] = b[i] - suma1 - suma2;
		
		x[i] = b[i] - sumaProdus(i, 0, i) - sumaProdus(i, i+1, n);
		x[i] /= A(i, i);
		
		deltaX += fabs(oldXI - x[i]);
	}
	return deltaX;
}

void MatriceRara::printX()
{
	for(int i = 0; i < n; i++) {
		printf("%f ", x[i]);
	}
	printf("\n");
}

void MatriceRara::rezolva()
{
	int k = 0;
	int kmax = 10;
	double delta;
	do {
		delta = iteratie();
		k++;
		printX();
	} while(delta > 0.000000001 && k < kmax && delta < 1000000000);
}