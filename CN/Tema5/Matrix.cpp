#include "Matrix.h"

Matrix::Matrix(char* fileName)
{
	n = 0;
	p = 0;
	A = 0;
	B = 0;
	
	if(ReadFile(fileName)) {
		n = 0;
		p = 0;
		//TODO
		//Stergerea memoriei
		A = 0;
		B = 0;
	}
}
	


bool Matrix::IsSymmetric()
{
	//Se verifica daca matricea este patrata
	if(!IsSquare()) {
		return false;
	}

	for(int i = 0; i < p; i++) {
		for(int j = 0; j < i; j++) {
			if(A[i][j] != A[j][i]) {
				return false;
			}
		}
	} 
	return true;
}

bool Matrix::IsSquare()
{
	return n == p;
}

void Matrix::MetodaPuterii()
{
	//TODO
}

void Matrix::MetodaIteratieiInverse()
{
	//TODO
}

void Matrix::SVD()
{
	//TODO
}

void Matrix::PrintMatrix()
{
	printf("p = %d\nn = %d\nA:", p, n);
	for(int i = 0; i < p; i++) {
		printf("\n");
		for(int j = 0; j < n; j++) {
			printf("%lf ", A[i][j]);
		}
	}

	printf("\nB:");
	for(int i = 0; i < p; i++) {
		printf("\n");
		printf("%lf ", B[i]);
	}

	if(IsSymmetric()) {
		printf("\nSymmetric Matrix");
	} else {
		printf("\nAsymmetric Matrix");
	}
}

int  Matrix::ReadFile(char* fileName)
{
	FILE* input = fopen(fileName, "r");
	if(!input) {
		//Eroare la deschiderea fisierului
		return -1;
	}

	//Citim dimensiunile fisierului
	fscanf(input, "%d %d", &p, &n);
	if(n <= 0 || p <= 0) {
		//Dimensiuni gresite
		return -2;
	}

	//Alocam memoria necesara
	A = (double**) malloc (p * sizeof(double*));
	B = (double* ) malloc (p * sizeof(double ));

	//Citim matricea
	for(int i = 0; i < p; i++) {
		//Alocam memorie pentru fiecare linie
		A[i] = (double*) malloc (n * sizeof(double));
		for(int j = 0; j < n; j++) {
			fscanf(input, "%lf", &A[i][j]);
		}
	}

	//Citim vectorul
	for(int i = 0; i < p; i++) {
		fscanf(input, "%lf", &B[i]);
	}

	fclose(input);
	return 0;
}